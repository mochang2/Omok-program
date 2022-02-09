using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace OmokProgram
{
    class Algorithm
    {
        // ↑, ↗, →, ↘, ↓, ↙, ←, ↖  
        private readonly int[] dx = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        private readonly int[] dy = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
        private readonly int lineCnt = 15;
        private int x;
        private int y;
        private STONE[,] board;

        // 게임이 끝났는지 확인하는 알고리즘. return bool
        public STONE checkOmok(STONE[,] board, int x, int y, STONE color)
        { // 승부 안남: none, 
            Console.WriteLine("color {0}", color.ToString());
            if (x < 0 || y < 0 || x >= lineCnt || y >= lineCnt) return STONE.none;
            int cnt = 1;
            this.x = x;
            this.y = y;
            this.board = board;

            switch (color)
            {
                case STONE.black: // 금수룰 적용 -> 승리인지 확인
                    // 1. 금수룰(열리고 연결된 33 44만)을 어겼는지 확인
                    if (x != 0 && y != 0 && x != lineCnt - 1 && y != lineCnt - 1) // 가장자리에 두지 않을 때만
                    {
                        List<Point> axisList = new List<Point>();
                        axisList = checkOpenDir1(x, y);
                        //Console.WriteLine("가로 방향 axisList count {0}", axisList.Count);
                        if (axisList.Count == 3) // 33 check
                        {
                            foreach(Point p in axisList)
                            {
                                if (checkOpenDir2(p.X, p.Y).Count == 3) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir3(p.X, p.Y).Count == 3) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 3) return STONE.white;
                            }
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir2(p.X, p.Y).Count == 4) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir3(p.X, p.Y).Count == 4) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 4) return STONE.white;
                            }
                        }

                        axisList = checkOpenDir2(x, y);
                        //Console.WriteLine("세로 방향 axisList count {0}", axisList.Count);
                        if (axisList.Count == 3) // 33 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 3) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir3(p.X, p.Y).Count == 3) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 3) return STONE.white;
                            }
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 4) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir3(p.X, p.Y).Count == 4) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 4) return STONE.white;
                            }
                        }

                        axisList = checkOpenDir3(x, y);
                        //Console.WriteLine("대각1 방향 axisList count {0}", axisList.Count);
                        if (axisList.Count == 3) // 33 check
                        {
                            foreach(Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 3) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir2(p.X, p.Y).Count == 3) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 3) return STONE.white;
                            }
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 4) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir2(p.X, p.Y).Count == 4) return STONE.white;
                                if (checkOpenDir4(p.X, p.Y).Count == 4) return STONE.white;
                            }
                        }

                        axisList = checkOpenDir4(x, y);
                        //Console.WriteLine("대각2 방향 axisList count {0}", axisList.Count);
                        if (axisList.Count == 3) // 33 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 3) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir2(p.X, p.Y).Count == 3) return STONE.white;
                                if (checkOpenDir3(p.X, p.Y).Count == 3) return STONE.white;
                            }
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            foreach (Point p in axisList)
                            {
                                if (checkOpenDir1(p.X, p.Y).Count == 4) return STONE.white; // 흑이 금수를 둠
                                if (checkOpenDir2(p.X, p.Y).Count == 4) return STONE.white;
                                if (checkOpenDir3(p.X, p.Y).Count == 4) return STONE.white;
                            }
                        }
                    }

                    // 2. 흑이 승리인지 확인
                    cnt = checkDir1();
                    if (cnt == 5) return STONE.black;

                    cnt = checkDir2();
                    if (cnt == 5) return STONE.black;

                    cnt = checkDir3();
                    if (cnt == 5) return STONE.black;

                    cnt = checkDir4();
                    if (cnt == 5) return STONE.black;

                    break;


                case STONE.white: // 승리인지만 확인
                    cnt = checkDir1();
                    if (cnt >= 5) return STONE.white;

                    cnt = checkDir2();
                    if (cnt >= 5) return STONE.white;

                    cnt = checkDir3();
                    if (cnt >= 5) return STONE.white;

                    cnt = checkDir4();
                    if (cnt >= 5) return STONE.white;

                    break;


                default:
                    break;
            }
                
            return STONE.none;
        }

        // 해당 좌표를 기준으로, 각 방향으로 열렸는지 확인
        // 가장자리에 대한 예외처리: 가장자리에 돌이 있다면 닫혀있는 것
        private List<Point> checkOpenDir1(int x, int y)
        {
            List<Point> tempList = new List<Point>();
            tempList.Add(new Point(x, y));
            int j;
            
            for (j = x + 1; j < lineCnt - 1; j++)
            {
                if (board[j, y] == board[x, y]) tempList.Add(new Point(j, y));
                else if (board[j, y] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if (j == lineCnt - 1 && board[j, y] != STONE.none) return new List<Point>();
            for (j = x - 1; j >= 1; j--)
            {
                if (board[j, y] == board[x, y]) tempList.Add(new Point(j, y));
                else if (board[j, y] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if (j == 0 && board[j, y] != STONE.none) return new List<Point>();

            return tempList;
        }
        private List<Point> checkOpenDir2(int x, int y)
        {
            List<Point> tempList = new List<Point>();
            tempList.Add(new Point(x, y));
            int i;
            
            for (i = y - 1; i >= 1; i--)
            {
                if (board[x, i] == board[x, y]) tempList.Add(new Point(x, i));
                else if (board[x, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if (i == 0 && board[x, i] != STONE.none) return new List<Point>();
            for (i = y + 1; i < lineCnt - 1; i++)
            {
                if (board[x, i] == board[x, y]) tempList.Add(new Point(x, i));
                else if (board[x, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if (i == lineCnt - 1 && board[x, i] != STONE.none) return new List<Point>();

            return tempList;
        }
        private List<Point> checkOpenDir3(int x, int y)
        {
            List<Point> tempList = new List<Point>();
            tempList.Add(new Point(x, y));
            int i, j;

            for (i = y - 1, j = x + 1; i >= 1 && j < lineCnt - 1; i--, j++)
            {
                if (board[j, i] == board[x, y]) tempList.Add(new Point(j, i));
                else if (board[j, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if ((i == 0 && board[j, i] != STONE.none) ||
                (j == lineCnt - 1 && board[j, i] != STONE.none)) return new List<Point>();
            for (i = y + 1, j = x - 1; i < lineCnt - 1 && j >= 1; i++, j--)
            {
                if (board[j, i] == board[x, y]) tempList.Add(new Point(j, i));
                else if (board[j, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if ((j == 0 && board[j, i] != STONE.none) ||
                (i == lineCnt - 1 && board[j, i] != STONE.none)) return new List<Point>();

            return tempList;
        }
        private List<Point> checkOpenDir4(int x, int y)
        {
            List<Point> tempList = new List<Point>();
            tempList.Add(new Point(x, y));
            int i, j;

            for (i = y - 1, j = x - 1; i >= 1 && j >= 1; i--, j--)
            {
                if (board[j, i] == board[x, y]) tempList.Add(new Point(j, i));
                else if (board[j, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if ((i == 0 && board[j,i] != STONE.none) ||
                (j == 0 && board[j,i] != STONE.none)) return new List<Point>();
            for (i = y + 1, j = x + 1; i < lineCnt - 1 && j < lineCnt - 1; i++, j++)
            {
                if (board[j, i] == board[x, y]) tempList.Add(new Point(j, i));
                else if (board[j, i] == STONE.none) break;  // 해당 방향으로 열림
                else return new List<Point>(); // 해당 방향으로 닫힘: 후보가 아님
            }
            if ((i == lineCnt - 1 && board[j, i] != STONE.none) ||
                (j == lineCnt - 1 && board[j, i] != STONE.none)) return new List<Point>();

            return tempList;
        }

        // 각 방향으로 이겼는지 확인
        private int checkDir1() // 가로: → => ← 연결된 돌의 수 확인
        {
            int cnt = 1;
            for (int j = x + 1; j < lineCnt; j++)
            {
                if (board[j, y] == board[x, y]) cnt++;
                else break;
            }
            for (int j = x - 1; j >= 0; j--)
            {
                if (board[j, y] == board[x, y]) cnt++;
                else break;
            }

            return cnt;
        }
        private int checkDir2() // 세로: ↑ => ↓ 연결된 돌의 수 확인
        {
            int cnt = 1;
            for (int i = y - 1; i >= 0; i--)
            {
                if (board[x, i] == board[x, y]) cnt++;
                else break;
            }
            for (int i = y + 1; i < lineCnt; i++)
            {
                if (board[x, i] == board[x, y]) cnt++;
                else break;
            }

            return cnt;
        }
        private int checkDir3() // 대각선1: ↗ => ↙ 연결된 돌의 수 확인
        {
            int cnt = 1;
            for (int i = y - 1, j = x + 1; i >= 0 && j < lineCnt; i--, j++)
            {
                if (board[j, i] == board[x, y]) cnt++;
                else break;
            }
            for (int i = y + 1, j = x - 1; i < lineCnt && j >= 0; i++, j--)
            {
                if (board[j, i] == board[x, y]) cnt++;
                else break;
            }

            return cnt;
        }
        private int checkDir4() // 대각선2: ↖ =>↘  연결된 돌의 수 확인
        {
            int cnt = 1;
            for (int i = y - 1, j = x - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[j, i] == board[x, y]) cnt++;
                else break;
            }
            for (int i = y + 1, j = x + 1; i < lineCnt && j < lineCnt; i++, j++)
            {
                if (board[j, i] == board[x, y]) cnt++;
                else break;
            }

            return cnt;
        }
        

        // AI 알고리즘. return Point or int[2] (X, Y)
        public int[] omokAI(STONE[,] board)
        {
            // need minimax
            Random random = new Random();
            int len = board.GetLength(0);
            int AIx, AIy;
            do
            {
                AIx = random.Next(len);
                AIy = random.Next(len);
            } while (board[AIx,AIy] != STONE.none);
            Thread.Sleep(1000);

            return new int[2] { AIx, AIy };
        }
    }
}
