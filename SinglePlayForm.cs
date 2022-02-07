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
        private Graphics g;
        public string playerColor = "";
        private string turn = "black";
        private bool playing = false;

        // initialization
        public SinglePlayForm()
        {
            InitializeComponent();
            Load += SinglePlayForm_Load;
            FormClosing += closing;
            closeProgram = true;
        }
        private void SinglePlayForm_Load(object sender, EventArgs e)
        {
            playing = true;
            Thread gameThread = new Thread(playGame);
            gameThread.Start();
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
            while (!playing)
            {
                if (playerColor == turn) // 플레이어 차례
                {
                    Console.WriteLine("player");
                    // 게임이 끝났는지 판단은 여기서 해.
                    turn = playerColor == "black" ? "white" : "black";
                }
                else // 컴퓨터 차례
                {
                    Console.WriteLine("computer");
                    // 게임이 끝났는지 판단은 여기서 해.
                    turn = playerColor == "black" ? "black" : "white";
                }
            }
        }
        // // TODO
        // 1. put(바둑알 놓기) 함수 구현하면 pnBoard에게서 좌표 받아와야 함.
        // 2. 해당 좌표를 기준으로 맞는 색깔에 따라 바둑알 표시.
        // 3. board 업데이트.
        // 4. 끝났는지 판단.
        // 5. pnBoard.axis를 -1,-1로 초기화 후 턴 넘겨줌.
        private void btnPut_Click(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[0] - pnBoard.gridSize / 2,
                pnBoard.margin + pnBoard.gridSize * pnBoard.axis[1] - pnBoard.gridSize / 2,
                pnBoard.stoneSize,
                pnBoard.stoneSize
            );
            pnBoard.pnSelectedSign.Location = new Point(-100,-100);
            if (turn == "black")
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneBlack.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.black;
                turn = "white";
            }
            else
            {
                Bitmap bmp = new Bitmap("../../Properties/stoneWhite.png");
                pnBoard.g.DrawImage(bmp, r);
                pnBoard.board[pnBoard.axis[0], pnBoard.axis[1]] = STONE.white;
                turn = "black";
            }
        }

        // close
        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}