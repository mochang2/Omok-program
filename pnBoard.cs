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
    public enum STONE {
        none = 0,
        black,
        white
    }
    public struct SEQUENCE_DATA
    {
        public Rectangle rectangle;
        public Brush brush;
        public SEQUENCE_DATA(Rectangle r, Brush b)
        {
            rectangle = r;
            brush = b;
        }
    }
    public partial class pnBoard : UserControl
    {
        // draw omok board
        private bool mounted = false;
        public int margin = 20;
        public int lineCnt = 15;
        public int gridSize = 25;
        public int stoneSize = 22;
        public int flowerSize = 8;
        public int selectSize = 16;
        public bool formMinimized = false;

        // game
        public int[] axis = new int[2] { -1, -1 }; // [0]: X, [1]: Y
        public STONE [,] board = new STONE [15, 15]; // 0: none, 1: black, 2: white  // (x,y)
        public Graphics g;
        public Pen pen;
        public Brush wBrush, bBrush, rBrush, boardBrush;
        public Font seqFont3D = new Font("맑은 고딕", 7, FontStyle.Bold);
        public Font seqFont2D = new Font("맑은 고딕", 9, FontStyle.Bold);
        public int stoneCnt = 0;
        public List<SEQUENCE_DATA> gameSeq = new List<SEQUENCE_DATA>();

        
        // initialize
        public pnBoard()
        {
            InitializeComponent();
            
            pen = new Pen(Color.Black);
            bBrush = new SolidBrush(Color.Black);
            wBrush = new SolidBrush(Color.White);
            rBrush = new SolidBrush(Color.Red);
            boardBrush = new SolidBrush(Color.FromArgb(255, (byte)203, (byte)188, (byte)107));
        }
        private void pnGameBoard_Paint(object sender, PaintEventArgs e)
        {
            g = pnGameBoard.CreateGraphics();
            if (!mounted)
            {
                mounted = true;
                drawBoard();
            }
            if (formMinimized)
            {
                drawBoard();
                drawStone(); 
                formMinimized = false;
            }
            // sequence 저장 List 사용
        }
        public void drawBoard()
        {
            for (int i = 0; i < lineCnt; i++) // 세로선
            {
                g.DrawLine(pen,
                  new Point(margin + i * gridSize, margin),
                  new Point(margin + i * gridSize, margin + (lineCnt - 1) * gridSize));
            }

            for (int i = 0; i < lineCnt; i++) // 가로선
            {
                g.DrawLine(pen,
                  new Point(margin, margin + i * gridSize),
                  new Point(margin + (lineCnt - 1) * gridSize, margin + i * gridSize));
            }

            for (int x = 3; x < lineCnt; x += 4) // 화점
            {
                for (int y = 3; y < lineCnt; y += 4)
                {
                    if ((x == 3 && y == 7) || (x == 7 && y == 3) ||
                        (x == 7 && y == 11) || (x == 11 && y == 7)) continue;
                    g.FillEllipse(bBrush,
                      margin + gridSize * x - flowerSize / 2,
                      margin + gridSize * y - flowerSize / 2,
                      flowerSize, flowerSize);
                }
            }
        }
        public void drawStone()
        {
            for (int x = 0; x < lineCnt; x++)
            {
                for (int y = 0; y < lineCnt; y++)
                {
                    if (board[x, y] == STONE.black)
                    {
                        Bitmap bmp = new Bitmap("../../Properties/stoneBlack.png");
                        g.DrawImage(bmp, 
                            margin + x * gridSize - stoneSize / 2,
                            margin + y * gridSize - stoneSize / 2,
                            stoneSize, stoneSize);
                    }
                    else if (board[x, y] == STONE.white)
                    {
                        Bitmap bmp = new Bitmap("../../Properties/stoneWhite.png");
                        g.DrawImage(bmp, 
                            margin + x * gridSize - stoneSize / 2,
                            margin + y * gridSize - stoneSize / 2,
                            stoneSize, stoneSize);
                    }
                }
            }

            StringFormat seqStringFormat = new StringFormat();
            seqStringFormat.Alignment = StringAlignment.Center;
            seqStringFormat.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < gameSeq.Count; i++) 
            {
                g.DrawString((i + 1).ToString(),
                    i >= 99 ? seqFont3D : seqFont2D,
                    gameSeq[i].brush, gameSeq[i].rectangle, seqStringFormat);
            }
        }


        // user interaction
        public void pnGameBoard_MouseDown(object sender, MouseEventArgs e)
        {
            axis[0] = (e.X - margin + gridSize / 2) / gridSize;
            axis[1] = (e.Y - margin + gridSize / 2) / gridSize;

            if (axis[0] < 0 || axis[0] >= 15 ||
                axis[1] < 0 || axis[1] >= 15 ||
                board[axis[0], axis[1]] != STONE.none)
                return;

            // pn으로 박지 말고.. 그리자.
            if (pnSelectedSign.Enabled == true)
            {
                if (pnSelectedSign.Visible == false) pnSelectedSign.Visible = true;
                pnSelectedSign.Location = new Point(margin + gridSize * axis[0] - selectSize / 2,
                                                    margin + gridSize * axis[1] - selectSize / 2);
            }
        }
    }
}
