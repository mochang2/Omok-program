using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmokProgram
{
    public partial class MultiPlayForm : Form
    {
        // winform
        private bool closeProgram;

        // multi threading
        Thread gameThread;

        // communication
        public string sip;
        public string sport;
        private Protocol protocol = new Protocol(0,0,0);
        private int protocolSize = 3;
        private byte[] buffer = new byte[3];
        private TcpClient client = null;
        private NetworkStream stream = null;

        // game
        private List<Point> forbiddenAxisList = new List<Point>();
        private bool playing = false;
        private STONE myColor;
        private STONE turn = STONE.black;
        private STONE winner = STONE.none;
        private Algorithm algorithm = new Algorithm();


        // initialization
        public MultiPlayForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(closing);
            closeProgram = true;

            Thread cur_thread = Thread.CurrentThread;
            Console.WriteLine("current thread id = {0}", cur_thread.ManagedThreadId);
        }
        private void MultiPlayForm_Load(object sender, EventArgs e)
        {
            try
            {
                // connection
                client = new TcpClient(sip, int.Parse(sport));
                stream = client.GetStream();
                stream.Write(ProtocoltoBytes(protocol), 0, protocolSize);
                stream.Read(buffer, 0, protocolSize);
                
                if (buffer[2] == 1)  // 연결 성공
                {
                    myColor = buffer[1] == 0 ? STONE.black : STONE.white;

                    // ready
                    protocol.command = (byte)1; protocol.data = (byte)1;
                    stream.Write(ProtocoltoBytes(protocol), 0, protocolSize);

                    playing = true;
                    gameThread = new Thread(playGame);
                    gameThread.IsBackground = true;  // 프로세스 종료시 스레드도 종료
                    gameThread.Name = "gameThread";
                    gameThread.Start();  // 게임 시작
                }
            }
            catch (Exception) {
                MessageBox.Show("연결이 되지 않았습니다. 다시 시도해주세요.");
            }
        }

        // play game 관련
        private void playGame()
        {
            Thread cur_thread = Thread.CurrentThread;
            Console.WriteLine("current thread id = {0}", cur_thread.ManagedThreadId);

            try
            {
                stream.Read(buffer, 0, protocolSize);
                if (buffer[0] == 2 && buffer[2] == 0) playing = true;  // 게임 시작
            }
            catch (Exception)
            {
                gameThread.Abort();
            }

            while (playing)
            {
                if (myColor == turn) // 내턴
                {
                    Console.WriteLine("my turn");
                    if (pnBoard.stoneCnt == 0) pnBoard.axis = new int[2] { 7, 7 }; // 선공이면 중앙에 두기
                    else pnBoard.axis = algorithm.fastAI(pnBoard.board, pnBoard.stoneCnt);
                    //pnBoard.axis = algorithm.miniMaxAI(pnBoard.board, myColor, pnBoard.stoneCnt);
                    Console.WriteLine("x: {0}, y: {1} 결정", pnBoard.axis[0], pnBoard.axis[1]);

                    protocol.command = (byte)3;
                    protocol.data = (byte)((pnBoard.axis[0] + 1 << 4) | (pnBoard.axis[1] + 1));
                    try
                    {
                        stream.Write(ProtocoltoBytes(protocol), 0, protocolSize); // send
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("서버로부터 연결이 끊어졌습니다.");
                    }

                    try
                    {
                        stream.Read(buffer, 0, protocolSize); // 내 턴 update receive

                        drawStone();
                        drawForbidden();
                        addTextToTbSeq();
                        turn = myColor == STONE.black ? STONE.white : STONE.black;
                        showTurn();
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("서버로부터 연결이 끊어졌습니다.");
                    }
                }

                // 상대방 턴
                if (buffer[0] != 4) // 내 턴에 이긴거로 끝난게 receive -> update
                {
                    Console.WriteLine("couunterpart's turn");
                    try
                    {
                        stream.Read(buffer, 0, protocolSize); // 상대방 턴 update receive
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("서버로부터 연결이 끊어졌습니다.");
                    }

                    pnBoard.axis[1] = (buffer[2] & 0x0f) - 1;
                    pnBoard.axis[0] = (buffer[2] >> 4) - 1;
                    if (pnBoard.axis[0] != -1 && pnBoard.axis[1] != -1)  // 상대방 오류로 인한 승리
                    {
                        drawStone();
                        addTextToTbSeq();
                    }
                }

                if (buffer[0] == 2) // update
                {
                    drawForbidden();
                    turn = myColor == STONE.black ? STONE.black : STONE.white;
                    showTurn();
                }
                else if (buffer[0] == 4) // end
                {
                    playing = false;
                    if (buffer[1] == (byte)1) winner = myColor; // 0이면 진 것. winner==STONE.none
                }
            }

            stream.Close();
            client.Close();
            Console.WriteLine("play finished!");
            if (buffer[2] != (byte)0 && buffer[2] != (byte)1)
            {
                showFinishReason();
                showFinishScreen();
            }
            else showFinishScreen();
        }
        private void drawStone()
        {
            Console.WriteLine("In drawStone x: {0}, y: {1}", pnBoard.axis[0], pnBoard.axis[1]);
            Rectangle r = new Rectangle(
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[0] - pnBoard.gridSize / 2,
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[1] - pnBoard.gridSize / 2,
                pnBoard.stoneSize,
                pnBoard.stoneSize
            );
            StringFormat seqStringFormat = new StringFormat();
            seqStringFormat.Alignment = StringAlignment.Center;
            seqStringFormat.LineAlignment = StringAlignment.Center;

            if (InvokeRequired)  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    pnBoard.pnSelectedSign.Location = new Point(-100, -100);
                }));
            }
            else pnBoard.pnSelectedSign.Location = new Point(-100, -100);

            if (turn == STONE.black)
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneBlack.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.black;

                pnBoard.g.DrawString((++pnBoard.stoneCnt).ToString(), pnBoard.seqFont,
                           pnBoard.wBrush, r, seqStringFormat);
                pnBoard.gameSeq.Add(new SEQUENCE_DATA(r, pnBoard.wBrush));
            }
            else
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneWhite.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.white;

                pnBoard.g.DrawString((++pnBoard.stoneCnt).ToString(), pnBoard.seqFont,
                           pnBoard.bBrush, r, seqStringFormat);
                pnBoard.gameSeq.Add(new SEQUENCE_DATA(r, pnBoard.bBrush));
            }
        }
        private void drawForbidden()
        {
            for (int i = 1; i < pnBoard.lineCnt - 1; i++)
            {
                for (int j = 1; j < pnBoard.lineCnt - 1; j++)
                {
                    if (pnBoard.board[j, i] != STONE.none) continue;
                    if (algorithm.checkForbidden(j, i, pnBoard.board))
                    {
                        forbiddenAxisList.Add(new Point(j, i));
                        if (InvokeRequired)
                        {
                            Invoke(new MethodInvoker(delegate ()
                            {
                                pnBoard.g.DrawString("X", Font, pnBoard.rBrush,
                                    pnBoard.margin + pnBoard.gridSize * j - pnBoard.gridSize / 4,
                                    pnBoard.margin + pnBoard.gridSize * i - pnBoard.gridSize / 4);
                            }));
                        }
                        else pnBoard.g.DrawString("X", Font, pnBoard.rBrush,
                                pnBoard.margin + pnBoard.gridSize * j - pnBoard.gridSize / 4,
                                pnBoard.margin + pnBoard.gridSize * i - pnBoard.gridSize / 4);
                    }
                    else
                    {
                        int index = forbiddenAxisList.FindIndex(x => x.X == j && x.Y == i);
                        if (index != -1)
                        {
                            forbiddenAxisList.RemoveAt(index);
                            if (InvokeRequired)
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    pnBoard.g.DrawString("X", Font, pnBoard.boardBrush,
                                        pnBoard.margin + pnBoard.gridSize * j - pnBoard.gridSize / 4,
                                        pnBoard.margin + pnBoard.gridSize * i - pnBoard.gridSize / 4);
                                }));
                            }
                            else pnBoard.g.DrawString("X", Font, pnBoard.boardBrush,
                                    pnBoard.margin + pnBoard.gridSize * j - pnBoard.gridSize / 4,
                                    pnBoard.margin + pnBoard.gridSize * i - pnBoard.gridSize / 4);
                        }
                    }
                }
            }
            pnBoard.drawBoard();
        }
        private void addTextToTbSeq()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    tbSeq.Text = turn.ToString() + ": (" + pnBoard.axis[0] + ", "
                        + pnBoard.axis[1] + ")\r\n" + tbSeq.Text;
                }));
            }
            else
            {
                tbSeq.Text = turn.ToString() + ": (" + pnBoard.axis[0] + ", "
                    + pnBoard.axis[1] + ")\r\n" + tbSeq.Text;
            }
        }
        private void showTurn()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (turn == STONE.black) lbTurn.BackColor = System.Drawing.Color.Black;
                    else if(turn == STONE.white) lbTurn.BackColor = System.Drawing.Color.White;
                }));
            }
            else
            {
                if (turn == STONE.black) lbTurn.BackColor = System.Drawing.Color.Black;
                else if (turn == STONE.white) lbTurn.BackColor = System.Drawing.Color.White;
            }
        }
        private void showFinishScreen()  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lbTurn.Visible = false;
                    btnReplay.Visible = true;
                    lbResult.Text = winner == myColor ? "WIN" : "LOSE";
                    lbResult.Visible = true;
                    pnBoard.drawBoard();
                    pnBoard.drawStone();
                }));
            }
            else
            {
                lbTurn.Visible = false;
                btnReplay.Visible = true;
                lbResult.Text = winner == myColor ? "WIN" : "LOSE";
                lbResult.Visible = true;
                pnBoard.drawBoard();
                pnBoard.drawStone();
            }
        }
        private void showFinishReason()
        {
            List<Point> points = algorithm.CheckOmok(pnBoard.board, pnBoard.axis[0], pnBoard.axis[1]);
            foreach(Point p in points)
            {
                Rectangle r = new Rectangle(
                    pnBoard.margin + pnBoard.gridSize * p.X - pnBoard.gridSize / 4,
                    pnBoard.margin + pnBoard.gridSize * p.Y - pnBoard.gridSize / 4,
                    pnBoard.stoneSize / 2,
                    pnBoard.stoneSize / 2
                );
                pnBoard.g.DrawEllipse(Pens.Red, r);
            }
        }

        // user interaction
        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            if (closeProgram == true) closeProgram = false;
            if (playing == true) playing = false;
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            Close();
            if (Application.OpenForms["mainForm"] != null)
                Application.OpenForms["mainForm"].WindowState = FormWindowState.Normal;
        }
        

        // close
        private void btnReplay_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            MultiPlayOptionForm multiPlayOptionForm = new MultiPlayOptionForm();
            Close();
            multiPlayOptionForm.Show();
        }
        private void closing(object sender, EventArgs e)
        {
            if (playing == true) playing = false;
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            if (closeProgram) Application.Exit();
        }
        

        // protocol
        public byte[] ProtocoltoBytes(Protocol p)
        {
            int size = Marshal.SizeOf(p);
            byte[] buffer = new byte[size];
            IntPtr iPtr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(p, iPtr, false); // 클래스 주소값 가져오기
            Marshal.Copy(iPtr, buffer, 0, size);
            Marshal.FreeHGlobal(iPtr);

            return buffer;
        }
        public Protocol BytestoProtocol(byte[] buffer)
        {
            int size = Marshal.SizeOf(typeof(Protocol));
            if (size > buffer.Length) return new Protocol();
            IntPtr iPtr = Marshal.AllocHGlobal(size);

            Marshal.Copy(buffer, 0, iPtr, size);
            Protocol p = (Protocol)Marshal.PtrToStructure(iPtr, typeof(Protocol));
            Marshal.FreeHGlobal(iPtr);
            return p;
        }
    }


    public struct Protocol
    {
        public byte command;
        public byte turn;
        public byte data;

        public Protocol(int c, int t, int d)
        {
            command = (byte)c;
            turn = (byte)t;
            data = (byte)d;
        }
    }
}