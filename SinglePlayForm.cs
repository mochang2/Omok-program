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
using System.Diagnostics;

namespace OmokProgram
{
    public partial class SinglePlayForm : Form
    {
        // win form
        private bool closeProgram;

        // multi threading
        Thread gameThread;
        private int oneTurnTime = 15;
        private Stopwatch stopwatch = new Stopwatch();
        private AutoResetEvent ar = new AutoResetEvent(false);

        // game
        public STONE playerColor;
        private STONE turn = STONE.black;
        private STONE winner;
        private Graphics g;
        private bool playing = false;
        private List<Point> forbiddenAxisList = new List<Point>();
        Algorithm algorithm = new Algorithm();
        

        // initialization
        public SinglePlayForm()
        {
            InitializeComponent();
            FormClosing += closing;
            closeProgram = true;
        }
        private void SinglePlayForm_Load(object sender, EventArgs e)
        {
            playing = true;
            gameThread = new Thread(playGame);
            gameThread.IsBackground = true;  // 프로세스 종료시 스레드도 종료.
            gameThread.Name = "gameThread";
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
            string black = playerColor == STONE.black ? "YOU" : "COM";
            string white = playerColor == STONE.white ? "YOU" : "COM";
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
            if (Application.OpenForms["mainForm"] != null)
                Application.OpenForms["mainForm"].WindowState = FormWindowState.Normal;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (lbTime.Text == "00초")
            {
                if (InvokeRequired)  // pnSelectedSign을 치움. 타이머 스레드에서 UI 스레드 접근. 크로스 스레딩.
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        pnBoard.pnSelectedSign.Location = new Point(-100, -100);
                    }));
                }
                else pnBoard.pnSelectedSign.Location = new Point(-100, -100);
                ar.Set();
            }
            lbTime.Text = (oneTurnTime - stopwatch.Elapsed.Seconds).ToString("D2") + "초" == "-01초" ?
                "--초" : (oneTurnTime - stopwatch.Elapsed.Seconds).ToString("D2") + "초";
        }
        public void playGame()
        {
            stopwatch.Start();

            while (playing)
            {
                if (playerColor == turn) // 플레이어 차례
                {
                    Console.WriteLine("player");

                    enableBtnPut();
                    changelbTurnText("Your Turn");
                    try  // 기권에 대한 예외처리(thread.Interrupt())
                    {
                        ar.WaitOne();  // drawStone() 포함됨
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("exception caused by surrender {0}", ex.ToString());
                        playing = false;
                        break;
                    }
                    winner = algorithm.checkOmok
                        (pnBoard.board, pnBoard.axis[0], pnBoard.axis[1],turn);
                    if (winner != STONE.none)
                    {
                        playing = false;
                        break;
                    }
                    turn = playerColor == STONE.black ? STONE.white : STONE.black;

                    Console.WriteLine("player finished");
                }
                else // 컴퓨터 차례
                {
                    Console.WriteLine("computer");

                    disableBtnPut();
                    changelbTurnText("Com's Turn");
                    try  // 기권에 대한 예외처리(thread.Interrupt())
                    {
                        pnBoard.axis = algorithm.omokAI(pnBoard.board);
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("exception caused by surrender {0}", ex.ToString());
                        playing = false;
                        break;
                    }
                    drawStone();
                    winner = algorithm.checkOmok
                        (pnBoard.board, pnBoard.axis[0], pnBoard.axis[1], turn);
                    if (winner != STONE.none)
                    {
                        playing = false;
                        break;
                    }
                    turn = playerColor == STONE.black ? STONE.black : STONE.white;

                    Console.WriteLine("computer finished");
                }

                if (pnBoard.stoneCnt == pnBoard.board.Length)  // 바둑판이 꽉 찼지만 승자가 없으면 무승부
                {
                    winner = STONE.none;
                    playing = false;
                    break;
                }
                drawForbidden();  // 흑돌에 대한 금수 적용 -> 화면에 X 표시
                pnBoard.axis = new int[2] { -1, -1 };    // 좌표 초기화
                stopwatch.Restart();  // 타이머 재시작
            }

            // 게임 종료
            stopwatch.Stop();
            Console.WriteLine("winner: {0}", winner);
            showFinishScreen();
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
            ar.Set();
        }
        private void enableBtnPut()  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    pnBoard.pnSelectedSign.Enabled = true;
                    btnPut.Enabled = true;
                }));
            else pnBoard.pnSelectedSign.Enabled = true; btnPut.Enabled = true;
        }
        private void disableBtnPut()  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    pnBoard.pnSelectedSign.Enabled = false;
                    btnPut.Enabled = false;
                }));
            else pnBoard.pnSelectedSign.Enabled = false; btnPut.Enabled = false;
        }
        private void changelbTurnText(string str)  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
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
            Console.WriteLine("x: {0}, y: {1}", pnBoard.axis[0], pnBoard.axis[1]);
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
        private void showFinishScreen()  // playGame 스레드에서 UI 스레드 접근. 크로스 스레딩.
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lbTime.Visible = false;
                    lbTurn.Visible = false;
                    btnPut.Visible = false;
                    btnSurrender.Visible = false;
                    hourGlassWrapper.Visible = false;
                    btnReplay.Visible = true;
                    btnClose.Visible = true;
                    lbResult.Visible = true;
                    if (winner == playerColor) lbResult.Text = "YOU WIN";
                    else if (winner == STONE.none) lbResult.Text = "YOU DRAW";
                    else lbResult.Text = "YOU LOSE";
                }));
            }
            else
            {
                lbTime.Visible = false;
                lbTurn.Visible = false;
                btnPut.Visible = false;
                btnSurrender.Visible = false;
                hourGlassWrapper.Visible = false;
                btnReplay.Visible = true;
                btnClose.Visible = true;
                lbResult.Visible = true;
                if (winner == playerColor) lbResult.Text = "YOU WIN";
                else if (winner == STONE.none) lbResult.Text = "YOU DRAW";
                else lbResult.Text = "YOU LOSE";
            }
        }
        private void btnSurrender_Click(object sender, EventArgs e)
        {
            winner = playerColor == STONE.black ? STONE.white : STONE.black;
            gameThread.Interrupt();
        }

        // close
        private void btnReplay_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            SinglePlayOptionForm singlePlayOptionForm = new SinglePlayOptionForm();
            Close();
            singlePlayOptionForm.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}