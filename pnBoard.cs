using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmokProgram
{
    public enum STONE {
        none = 0,
        black,
        white
    }
    public partial class pnBoard : UserControl
    {
        // draw omok board
        public int margin = 20;
        public int lineCnt = 15;
        public int gridSize = 25;
        public int stoneSize = 22;
        public int flowerSize = 8;
        public int selectSize = 16;

        // game
        public int[] axis = new int[2] { -1, -1 }; // [0]: X, [1]: Y
        public STONE [,] board = new STONE [15, 15]; // 0: none, 1: black, 2: white  // (x,y)
        public Graphics g;
        public Pen pen;
        public Brush wBrush, bBrush, rBrush;

        // initialize
        public pnBoard()
        {
            InitializeComponent();

            pen = new Pen(Color.Black);
            bBrush = new SolidBrush(Color.Black);
            wBrush = new SolidBrush(Color.White);
            rBrush = new SolidBrush(Color.Red);
        }
        private void pnGameBoard_Paint(object sender, PaintEventArgs e)
        {
            g = pnGameBoard.CreateGraphics();

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

        // user interaction
        private void pnGameBoard_MouseDown(object sender, MouseEventArgs e)
        {
            axis[0] = (e.X - margin + gridSize / 2) / gridSize;
            axis[1] = (e.Y - margin + gridSize / 2) / gridSize;

            if (axis[0] < 0 || axis[0] >= 15 ||
                axis[1] < 0 || axis[1] >= 15 ||
                board[axis[0], axis[1]] != STONE.none)
                return;

            // pn으로 박지 말고.. 그리자.
            if (pnSelectedSign.Visible == false) pnSelectedSign.Visible = true;
            pnSelectedSign.Location = new Point(margin + gridSize * axis[0] - selectSize / 2,
                                                margin + gridSize * axis[1] - selectSize / 2);
        }

        //private int[] GetRowColIndex(TableLayoutPanel tlp, Point point)
        //{
        //    //axis = GetRowColIndex(this.tableLayoutPanel,
        //    //  this.tableLayoutPanel.PointToClient(Cursor.Position));
        //    if (point.X > tlp.Width || point.Y > tlp.Height)
        //        return new int[] { -1, -1 };

        //    int w = tlp.Width;
        //    int h = tlp.Height;
        //    int[] widths = tlp.GetColumnWidths();

        //    int i;
        //    for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
        //        w -= widths[i];
        //    int col = i + 1;

        //    int[] heights = tlp.GetRowHeights();
        //    for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
        //        h -= heights[i];

        //    int row = i + 1;

        //    return new int[] { col, row };
        //}


    }
}
