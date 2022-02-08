using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmokProgram
{
    public partial class SinglePlayForm : Form
    {
        // win form
        public delegate void mainFormMaximizeHandler(object sender, EventArgs e);
        public event mainFormMaximizeHandler mainFormNormal;
        private bool closeProgram;

        // game
        public string playerColor = "";
        private Graphics g;
        private string turn = "black";
        private bool playing = false;
        private SharedData sharedTurn = new SharedData();

        // initialization
        public SinglePlayForm()
        {
            InitializeComponent();
            //Load += SinglePlayForm_Load;
            FormClosing += closing;
            closeProgram = true;
        }
        private void SinglePlayForm_Load(object sender, EventArgs e)
        {
            playing = true;
            Thread gameThread = new Thread(playGame);
            gameThread.IsBackground = true;  // 프로세스 종료시 스레드도 종료.
            gameThread.Start();
        }
        private void SinglePlayForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                pnBoard.formMinimized = true;
            }
        }
        private void pnShowColor_Paint(object sender, PaintEventArgs e)
        {
            string black = playerColor == "black" ? "YOU" : "COM";
            string white = playerColor == "white" ? "YOU" : "COM";
            Font font = new Font("Arial", 14);
            SolidBrush solidbrush = new SolidBrush(Color.Black); // pnBoard 꺼 써보기.
            StringFormat sf = new StringFormat();

            g = pnShowColor.CreateGraphics();
            g.FillEllipse(Brushes.Black, 1, 8, 24, 24);
            g.DrawString(black, font, solidbrush, 28, 10, sf);
            g.DrawEllipse(Pens.Black, 85, 8, 24, 24);
            g.DrawString(white, font, solidbrush, 112, 10, sf);
        }

        // user interaction
        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            Close();
            mainFormNormal(sender, e);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            // 00초인거 학인해야 함
            lbTime.Text = (int.Parse(lbTime.Text.Substring(0, 2)) - 1).ToString("D2") + "초";
        }
        public void playGame()
        {
            while (playing)
            {
                if (playerColor == turn) // 플레이어 차례
                {
                    Console.WriteLine("player");

                    enableBtnPut();
                    changelbTurnText("Your Turn");
                    while (sharedTurn.playerTurn) Thread.Sleep(10);  // 너무 빠르게 확인 못하게
                    // thread signal
                    // 게임이 끝났는지 판단은 여기서 해. => playing == false
                    turn = playerColor == "black" ? "white" : "black";

                    Console.WriteLine("player finished");
                }
                else // 컴퓨터 차례
                {
                    Console.WriteLine("computer");

                    disableBtnPut();
                    changelbTurnText("Com's Turn");
                    Thread.Sleep(1000);
                    // 여기는 ai 알고리즘 돌려야 함.
                    // 해당 return 값을 pnBoard.axis[0],[1]에 저장
                    // drawStone();
                    sharedTurn.computerTurnFinished();
                    // 게임이 끝났는지 판단은 여기서 해. => playing == false
                    turn = playerColor == "black" ? "black" : "white";

                    Console.WriteLine("computer finished");
                }

                pnBoard.axis = new int[2] { -1, -1 };    // 좌표 초기화
            }

            // playing == false => btn.Visible == true로 변경
        }
        private void btnPut_Click(object sender, EventArgs e)
        {
            if (pnBoard.axis[0] < 0 || pnBoard.axis[0] >= 15 ||
               pnBoard.axis[1] < 0 || pnBoard.axis[1] >= 15 ||
               pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] != STONE.none)
            {
                Console.WriteLine("좌표 {0} {1}", pnBoard.axis[0], pnBoard.axis[1]);
                Console.WriteLine("금지된 위치");
                MessageBox.Show("착수 위치를 다시 지정해주세요");
                return;
            }
                
            drawStone();
            sharedTurn.playerTurnFinished();
        }
        private void enableBtnPut()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    pnBoard.pnSelectedSign.Enabled = true;
                    btnPut.Enabled = true;
                }));
            else pnBoard.pnSelectedSign.Enabled = true; btnPut.Enabled = true;
        }
        private void disableBtnPut()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    pnBoard.pnSelectedSign.Enabled = false;
                    btnPut.Enabled = false;
                }));
            else pnBoard.pnSelectedSign.Enabled = false; btnPut.Enabled = false;
        }
        private void changelbTurnText(string str)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    lbTurn.Text = str;
                }));
            else lbTurn.Text = str;
        }
        private void drawStone()
        {
            Rectangle r = new Rectangle(
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[0] - pnBoard.gridSize / 2,
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[1] - pnBoard.gridSize / 2,
                pnBoard.stoneSize,
                pnBoard.stoneSize
            );
            StringFormat seqStringFormat = new StringFormat();
            seqStringFormat.Alignment = StringAlignment.Center;
            seqStringFormat.LineAlignment = StringAlignment.Center;

            pnBoard.pnSelectedSign.Location = new Point(-100, -100);
            if (turn == "black")
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneBlack.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.black;

                Brush b = Brushes.White;
                pnBoard.g.DrawString((++pnBoard.stoneCnt).ToString(), pnBoard.seqFont,
                                    b, r, seqStringFormat);
                pnBoard.gameSeq.Add(new SEQUENCE_DATA(r, b));
            }
            else
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneWhite.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.white;

                Brush b = Brushes.Black;
                pnBoard.g.DrawString((++pnBoard.stoneCnt).ToString(), pnBoard.seqFont,
                                    b, r, seqStringFormat);
                pnBoard.gameSeq.Add(new SEQUENCE_DATA(r, b));
            }
        }

        // close
        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }

    public class SharedData
    {
        private object obj = new object();
        public bool playerTurn = true;

        public void playerTurnFinished()
        {
            lock (obj)
            {
                if (playerTurn) playerTurn = false;
            }
        }
        public void computerTurnFinished()
        {
            lock (obj)
            {
                if (!playerTurn) playerTurn = true;
            }
        }
    }
}