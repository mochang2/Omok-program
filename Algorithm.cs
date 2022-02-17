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
        private readonly int lineCnt = 15;
        private int x;
        private int y;
        private STONE[,] board;    // 바둑판


        public bool checkForbidden(int x, int y, STONE[,] board)
        {
            this.x = x;
            this.y = y;
            this.board = board;
            this.board[x, y] = STONE.black;  // 해당 빈 공간이 검정돌일 때를 가정

            List<Point> axisList = checkOpenDir1(x, y);
            if (axisList.Count == 3) // 33 check
            {
                if ((checkOpenDir2(x, y).Count == 3) ||
                    (checkOpenDir3(x, y).Count == 3) ||
                    (checkOpenDir4(x, y).Count == 3))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                if ((checkOpenDir2(x, y).Count == 4) ||
                    (checkOpenDir3(x, y).Count == 4) ||
                    (checkOpenDir4(x, y).Count == 4))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }

            axisList = checkOpenDir2(x, y);
            if (axisList.Count == 3) // 33 check
            {
                if ((checkOpenDir1(x, y).Count == 3) ||
                    (checkOpenDir3(x, y).Count == 3) ||
                    (checkOpenDir4(x, y).Count == 3))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                if ((checkOpenDir1(x, y).Count == 4) ||
                    (checkOpenDir3(x, y).Count == 4) ||
                    (checkOpenDir4(x, y).Count == 4))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }

            axisList = checkOpenDir3(x, y);
            if (axisList.Count == 3) // 33 check
            {
                if ((checkOpenDir1(x, y).Count == 3) ||
                    (checkOpenDir2(x, y).Count == 3) ||
                    (checkOpenDir4(x, y).Count == 3))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                if ((checkOpenDir1(x, y).Count == 4) ||
                    (checkOpenDir2(x, y).Count == 4) ||
                    (checkOpenDir4(x, y).Count == 4))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }

            axisList = checkOpenDir4(x, y);
            if (axisList.Count == 3) // 33 check
            {
                if ((checkOpenDir1(x, y).Count == 3) ||
                    (checkOpenDir2(x, y).Count == 3) ||
                    (checkOpenDir3(x, y).Count == 3))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                if ((checkOpenDir1(x, y).Count == 4) ||
                    (checkOpenDir2(x, y).Count == 4) ||
                    (checkOpenDir3(x, y).Count == 4))
                {
                    this.board[x, y] = STONE.none;
                    return true;
                }
            }

            this.board[x, y] = STONE.none;
            return false;
        }

        // 게임이 끝났는지 확인하는 알고리즘. return winner
        public STONE checkOmok(STONE[,] board, int x, int y, STONE color)
        { // 승부 안남: none, 
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
                        List<Point> axisList = checkOpenDir1(x, y);
                        if (axisList.Count == 3) // 33 check
                        {
                            if (checkOpenDir2(x, y).Count == 3) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir3(x, y).Count == 3) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 3) return STONE.white;
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            if (checkOpenDir2(x, y).Count == 4) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir3(x, y).Count == 4) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 4) return STONE.white;
                        }

                        axisList = checkOpenDir2(x, y);
                        if (axisList.Count == 3) // 33 check
                        {
                            if (checkOpenDir1(x, y).Count == 3) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir3(x, y).Count == 3) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 3) return STONE.white;
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            if (checkOpenDir1(x, y).Count == 4) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir3(x, y).Count == 4) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 4) return STONE.white;
                        }

                        axisList = checkOpenDir3(x, y);
                        if (axisList.Count == 3) // 33 check
                        {
                            if (checkOpenDir1(x, y).Count == 3) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir2(x, y).Count == 3) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 3) return STONE.white;
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            if (checkOpenDir1(x, y).Count == 4) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir2(x, y).Count == 4) return STONE.white;
                            if (checkOpenDir4(x, y).Count == 4) return STONE.white;
                        }

                        axisList = checkOpenDir4(x, y);
                        if (axisList.Count == 3) // 33 check
                        {
                            if (checkOpenDir1(x, y).Count == 3) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir2(x, y).Count == 3) return STONE.white;
                            if (checkOpenDir3(x, y).Count == 3) return STONE.white;
                        }
                        else if (axisList.Count == 4) // 44 check
                        {
                            if (checkOpenDir1(x, y).Count == 4) return STONE.white; // 흑이 금수를 둠
                            if (checkOpenDir2(x, y).Count == 4) return STONE.white;
                            if (checkOpenDir3(x, y).Count == 4) return STONE.white;
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

        // 이긴 이유(5목) 반환하는 알고리즘
        public List<Point> CheckOmok(STONE[,] board, int x, int y)
        { 
            if (x < 0 || y < 0 || x >= lineCnt || y >= lineCnt) return new List<Point>();
            this.board = board;
            this.x = x;
            this.y = y;
            List<Point> points;

            points = checkDir11();
            if (points.Count >= 5) return points;

            points = checkDir22();
            if (points.Count >= 5) return points;

            points = checkDir33();
            if (points.Count >= 5) return points;

            points = checkDir44();
            if (points.Count >= 5) return points;

            return new List<Point>();
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

        // 해당 위치에 두면 각 방향으로 몇 개가 이어졌는지 / 열렸는지 / 한 칸 띄었는지
        private WeightInfo checkDir1(int x, int y, STONE color) // 가로: → => ← 연결된 돌의 수 확인
        {
            int connectCnt = 1;
            int closedCnt = 0;
            bool jump = false;
            int j;
            for (j = x + 1; j < lineCnt; j++)
            {
                if (board[j, y] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, y] != color && board[j, y] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, y] == STONE.none && jump == true) break;  // 빈 칸 일 때1.
                else  // 빈 칸 일 때2  /*(board[j, y] == STONE.none && jump == false)*/
                {
                    if (j + 1 < lineCnt && board[j + 1, y] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (j == lineCnt) closedCnt++;
            for (j = x - 1; j >= 0; j--)
            {
                if (board[j, y] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, y] != color && board[j, y] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, y] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2  /*(board[j, y] == STONE.none && jump == false)*/
                {
                    if (j - 1 >= 0 && board[j - 1, y] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (j == -1) closedCnt++;

            return new WeightInfo(connectCnt, closedCnt, jump);
        }
        private WeightInfo checkDir2(int x, int y, STONE color) // 세로: ↑ => ↓ 연결된 돌의 수 확인
        {
            int connectCnt = 1;
            int closedCnt = 0;
            bool jump = false;
            int i;
            for (i = y - 1; i >= 0; i--)
            {
                if (board[x, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[x, i] != color && board[x, i] != STONE.none) // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[x, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[x, i] == STONE.none && jump == false)*/
                {
                    if (i - 1 >= 0 && board[x, i - 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == -1) closedCnt++;
            for (i = y + 1; i < lineCnt; i++)
            {
                if (board[x, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[x, i] != color && board[x, i] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[x, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[x, i] == STONE.none && jump == false)*/ 
                {
                    if (i + 1 < lineCnt && board[x, i + 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == lineCnt) closedCnt++;

            return new WeightInfo(connectCnt, closedCnt, jump);
        }
        private WeightInfo checkDir3(int x, int y, STONE color) // 대각선1: ↗ => ↙ 연결된 돌의 수 확인
        {
            int connectCnt = 1;
            int closedCnt = 0;
            bool jump = false;
            int i, j;
            for (i = y - 1, j = x + 1; i >= 0 && j < lineCnt; i--, j++)
            {
                if (board[j, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, i] != color && board[j, i] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[j, i] == STONE.none && jump == false)*/
                {
                    if (i - 1 >= 0 && j + 1 < lineCnt && board[j + 1, i - 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == -1 || j == lineCnt) closedCnt++;
            for (i = y + 1, j = x - 1; i < lineCnt && j >= 0; i++, j--)
            {
                if (board[j, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, i] != color && board[j, i] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[j, i] == STONE.none && jump == false)*/
                {
                    if (i + 1 < lineCnt && j - 1 >= 0 && board[j - 1, i + 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == lineCnt || j == -1) closedCnt++;

            return new WeightInfo(connectCnt, closedCnt, jump);
        }
        private WeightInfo checkDir4(int x, int y, STONE color) //  대각선2: ↖ =>↘  연결된 돌의 수 확인
        {
            int connectCnt = 1;
            int closedCnt = 0;
            bool jump = false;
            int i, j;
            for (i = y - 1, j = x - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[j, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, i] != color && board[j, i] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[j, i] == STONE.none && jump == false)*/
                {
                    if (i - 1 >= 0 && j - 1 >= 0 && board[j - 1, i - 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == -1 || j == -1) closedCnt++;
            for (i = y + 1, j = x + 1; i < lineCnt && j < lineCnt; i++, j++)
            {
                if (board[j, i] == color) connectCnt++;  // 같은 색일 때
                else if (board[j, i] != color && board[j, i] != STONE.none)  // 다른 색일 때
                {
                    closedCnt++;
                    break;
                }
                else if (board[j, i] == STONE.none && jump == true) break;  // 빈 칸 일 때1
                else  // 빈 칸 일 때2 /*(board[j, i] == STONE.none && jump == false)*/
                {
                    if (i + 1 < lineCnt && j + 1 < lineCnt && board[j + 1, i + 1] == color) jump = true;  // 점프해서 다시 내 색깔일 때
                    else break;
                }
            }
            if (i == lineCnt || j == lineCnt) closedCnt++;

            return new WeightInfo(connectCnt, closedCnt, jump);
        }

        // 각 방향으로 이겼는지 확인. int 반환(개수)
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

        // 각 방향으로 이겼는지 확인. List<Point> 반환(좌표)
        private List<Point> checkDir11() // 가로: → => ← 연결된 돌의 수 확인
        {
            List<Point> points = new List<Point>() { new Point(x, y) };
            for (int j = x + 1; j < lineCnt; j++)
            {
                if (board[j, y] == board[x, y]) points.Add(new Point(j, y));
                else break;
            }
            for (int j = x - 1; j >= 0; j--)
            {
                if (board[j, y] == board[x, y]) points.Add(new Point(j, y));
                else break;
            }

            return points;
        }
        private List<Point> checkDir22() // 세로: ↑ => ↓ 연결된 돌의 수 확인
        {
            List<Point> points = new List<Point>() { new Point(x, y) };
            for (int i = y - 1; i >= 0; i--)
            {
                if (board[x, i] == board[x, y]) points.Add(new Point(x, i));
                else break;
            }
            for (int i = y + 1; i < lineCnt; i++)
            {
                if (board[x, i] == board[x, y]) points.Add(new Point(x, i));
                else break;
            }

            return points;
        }
        private List<Point> checkDir33() // 대각선1: ↗ => ↙ 연결된 돌의 수 확인
        {
            List<Point> points = new List<Point>() { new Point(x, y) };
            for (int i = y - 1, j = x + 1; i >= 0 && j < lineCnt; i--, j++)
            {
                if (board[j, i] == board[x, y]) points.Add(new Point(j, i));
                else break;
            }
            for (int i = y + 1, j = x - 1; i < lineCnt && j >= 0; i++, j--)
            {
                if (board[j, i] == board[x, y]) points.Add(new Point(j, i));
                else break;
            }

            return points;
        }
        private List<Point> checkDir44() // 대각선2: ↖ =>↘  연결된 돌의 수 확인
        {
            List<Point> points = new List<Point>() { new Point(x, y) };
            for (int i = y - 1, j = x - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[j, i] == board[x, y]) points.Add(new Point(j, i));
                else break;
            }
            for (int i = y + 1, j = x + 1; i < lineCnt && j < lineCnt; i++, j++)
            {
                if (board[j, i] == board[x, y]) points.Add(new Point(j, i));
                else break;
            }

            return points;
        }


        private int cmpFunc(WeightInfo a, WeightInfo b)
        {
            if (a.connectCnt > b.connectCnt) return -1;
            else if (a.connectCnt < b.connectCnt) return 1;
            else
            {
                if (a.closedCnt < b.closedCnt) return -1;
                else if (a.closedCnt > b.closedCnt) return 11;
                else return 0;
            }
        }

            // 가중치 부여. 내 턴마다 새롭게 가중치판을 생성.
        public int[,] addWeight(STONE AIColor)
        {
            int[,] w_board = new int[lineCnt, lineCnt];  // 가중치판. 0으로 초기화
            STONE stone;
            bool gameover = false;  // gameover == true이면 더이상 가중치 계산을 그만함

            switch (AIColor)
            {
                case STONE.black:  // 금수 위치 가중치 조정o
                    // 해당 위치에 자신의 돌, 즉 black을 놓을 때 가중치를 더함
                    stone = STONE.black;
                    for (int j = 0; j < lineCnt; j++)
                    {
                        for (int i = 0; i < lineCnt; i++)
                        {
                            if (board[j, i] != STONE.none) continue;
                            if (j > 0 && j < lineCnt - 1 &&
                                i > 0 && i < lineCnt - 1 &&
                                checkForbidden(j, i, board))  // 금수 위치
                            {
                                w_board[j, i] = -(int)Weight.Gameover;
                                continue;
                            }

                            int c5 = 0;  // connect - closed - jump
                            int c4C0F = 0;
                            int c4C1F = 0;
                            int c4C0T = 0;
                            int c4C1T = 0;
                            int c3C0F = 0;
                            int c3C1F = 0;
                            int c3C0T = 0;
                            int c3C1T = 0;
                            int c2C0F = 0;
                            int c2C1F = 0;
                            int c2C0T = 0;
                            int c2C1T = 0;

                            List<WeightInfo> li = new List<WeightInfo>(); // 4방향 확인
                            board[j, i] = stone;  // 연결된 5 뒤에 한 칸 띄고 같은 색이 또 있는 edge case를 제거하기 위해
                            if (checkOmok(board, j, i, stone) == stone)
                            {
                                li.Add(new WeightInfo(5, 0, false));
                            }
                            else
                            {
                                li.Add(checkDir1(j, i, stone));
                                li.Add(checkDir2(j, i, stone));
                                li.Add(checkDir3(j, i, stone));
                                li.Add(checkDir4(j, i, stone));
                            }
                            board[j, i] = STONE.none;

                            foreach (WeightInfo wi in li)
                            {
                                if (wi.connectCnt == 5 && wi.jump == false) c5++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == false) c4C0F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == false) c4C1F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == true) c4C0T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == true) c4C1T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == false) c3C0F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == false) c3C1F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == true) c3C0T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == true) c3C1T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == false) c2C0F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == false) c2C1F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == true) c2C0T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == true) c2C1T++;
                            }

                            // 게임 종료
                            if (c5 >= 1)  // 5목  // 11, 3확인
                            {
                                w_board[j, i] += (int)Weight.Gameover;
                                gameover = true;
                                break;
                            }
                            // 필승 카드
                            if (c4C0F >= 1)  // 이어진, 열린 4가 포함됨
                            {
                                w_board[j, i] += (int)Weight.Open4;
                                c4C0F = 0;
                            }
                            else if (c4C1T + c4C1F >= 1 && c3C0F >= 1)  // 한쪽만 닫힌4 + 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.Closed4Open3;
                                c4C1T = 0;
                                c4C1F = 0;
                                c3C0F = 0;
                            }
                            else if (c3C0T >= 1 && c3C0F >= 1)  // 하나는 띄어진, 열린 33
                            {
                                w_board[j, i] += (int)Weight.OpenJump33;
                                c3C0T = 0;
                                c3C0F = 0;
                            }
                            // 가중치 합 필요
                            if ((c4C1T + c4C1F >= 1 && c3C0T >= 1) ||
                                (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)) // 막을 수 있는 43
                            {
                                w_board[j, i] += (int)Weight.NoVictory43;
                                if (c4C1T + c4C1F >= 1 && c3C0T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C0T = 0;
                                }
                                else if (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C1F = 0;
                                    c3C1T = 0;
                                }
                            }
                            if (c4C0T >= 1)  // 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c3C0F + c3C0T == 1 && c2C0F + c2C0T >= 1)  // 열린 32
                            {
                                w_board[j, i] += (int)Weight.Open32;
                                c3C0F = 0;
                                c3C0T = 0;
                                c2C0F = 0;
                                c2C0T = 0;
                            }
                            if (c2C0T + c2C0F >= 3)  // 열린 222
                            {
                                w_board[j, i] += (int)Weight.Open222;
                                c2C0T = 0;
                                c2C0F = 0;
                            }
                            if (c3C0F >= 1)  // 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenNojump3;
                            }
                            if (c3C0T >= 1)  // 한 칸 띄어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenJump3;
                            }
                            if (c4C1F >= 1)  // 이어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump4;
                            }
                            if (c4C1T >= 1)  // 띄어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedJump4;
                            }
                            if (c3C1T >= 1)  // 띄어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedJump3;
                            }
                            if (c3C1F >= 1)  // 이어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump3;
                            }
                            if (c2C0F >= 1)  // 이어진, 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenNoJump2;
                            }
                            if (c2C0T >= 1)  // 떨어진, 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenJump2;
                            }
                            if (c2C1F >= 1)  // 닫힌 2
                            {
                                w_board[j, i] += (int)Weight.Closed2;
                            }
                        }
                        if (gameover) break;
                    }
                    if (gameover) break;


                    // 해당 위치에 상대방 돌, 즉 white를 놓을 때 가중치를 더함
                    stone = STONE.white;
                    for (int j = 0; j < lineCnt; j++)
                    {
                        for (int i = 0; i < lineCnt; i++)
                        {
                            if (board[j, i] != STONE.none || w_board[j,i] < -100000) continue;  // 금수 위치는 절대 고려 x
                            

                            int c5F = 0;  // connect - closed - jump
                            int c5C0T = 0;  // 가중치 임의로 넣음
                            int c5C1T = 0;  // 가중치 임의로 넣음
                            int c5C2T = 0;  // 가중치 임의로 넣음
                            int c4C0F = 0;
                            int c4C1F = 0;
                            int c4C0T = 0;
                            int c4C1T = 0;
                            int c3C0F = 0;
                            int c3C1F = 0;
                            int c3C0T = 0;
                            int c3C1T = 0;
                            int c2C0F = 0;
                            int c2C1F = 0;
                            int c2C0T = 0;
                            int c2C1T = 0;


                            List<WeightInfo> li = new List<WeightInfo>(); // 4방향 확인
                            board[j, i] = stone;  // 연결된 5 뒤에 한 칸 띄고 같은 색이 또 있는 edge case를 제거하기 위해
                            if (checkOmok(board, j, i, stone) == stone)
                            {
                                li.Add(new WeightInfo(5, 0, false));
                            }
                            else
                            {
                                li.Add(checkDir1(j, i, stone));
                                li.Add(checkDir2(j, i, stone));
                                li.Add(checkDir3(j, i, stone));
                                li.Add(checkDir4(j, i, stone));
                            }
                            board[j, i] = STONE.none;

                            foreach (WeightInfo wi in li)
                            {
                                if (wi.connectCnt >= 5 && wi.jump == false) c5F++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 0) c5C0T++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 1) c5C1T++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 2) c5C2T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == false) c4C0F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == false) c4C1F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == true) c4C0T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == true) c4C1T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == false) c3C0F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == false) c3C1F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == true) c3C0T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == true) c3C1T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == false) c2C0F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == false) c2C1F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == true) c2C0T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == true) c2C1T++;
                            }

                            // 게임끝
                            if (c5F >= 1)  // 5목 + 장목
                            {
                                w_board[j, i] += (int)Weight.Gameover;
                                gameover = true;
                                break;
                            }
                            // 필승카드
                            if (c4C0F >= 1)  // 이어진, 열린 4가 포함됨
                            {
                                w_board[j, i] += (int)Weight.Open4;
                                c4C0F = 0;
                            }
                            else if (c4C1T + c4C1F >= 1 && c3C0F >= 1)  // 한쪽만 닫힌4 + 이어진, 열린3
                            {
                                w_board[j, i] += (int)Weight.Closed4Open3;
                                c4C1T = 0;
                                c4C1F = 0;
                                c3C0F = 0;
                            }
                            else if (c3C0F + c3C0T >= 2)  // 열린 3이 2 개 이상
                            {
                                w_board[j, i] += (int)Weight.OpenNoJump33;
                                c3C0T = 0;
                                c3C0F = 0;
                            }
                            // 가중치 합 필요
                            if ((c4C1T + c4C1F >= 1 && c3C0T >= 1) ||
                                (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)) // 막을 수 있는 43
                            {
                                w_board[j, i] += (int)Weight.NoVictory43;
                                if (c4C1T + c4C1F >= 1 && c3C0T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C0T = 0;
                                }
                                else if (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C1F = 0;
                                    c3C1T = 0;
                                }
                            }
                            if (c4C0T == 1)  // 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c5C0T >= 1)  // 6목이 가능한 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c3C0F + c3C0T == 1 && c2C0F + c2C0T >= 1)  // 열린 32
                            {
                                w_board[j, i] += (int)Weight.Open32;
                                c3C0F = 0;
                                c3C0T = 0;
                                c2C0F = 0;
                                c2C0T = 0;
                            }
                            if (c2C0T + c2C0F >= 3)  // 열린 222
                            {
                                w_board[j, i] += (int)Weight.Open222;
                                c2C0T = 0;
                                c2C0F = 0;
                            }
                            if (c3C0F >= 1)  // 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenNojump3;
                            }
                            if (c3C0T >= 1 || c5C1T >= 1)  // 한 칸 띄어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenJump3;
                            }
                            if (c4C1F >= 1 || c5C2T >= 1)  // 이어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump4;
                            }
                            if (c4C1T >= 1)  // 띄어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedJump4;
                            }
                            if (c3C1T >= 1)  // 띄어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedJump3;
                            }
                            if (c3C1F >= 1)  // 이어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump3;
                            }
                            if (c2C0F + c2C0T >= 1)  // 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenJump2;
                            }
                            if (c2C1F + c2C1T >= 1)  // 닫힌 2
                            {
                                w_board[j, i] += (int)Weight.Closed2;
                            }
                        }
                        if (gameover) break;
                    }
                    break;


                case STONE.white:  // 금수 위치 가중치 조정x. 그냥 내가 유리해지기만 하는지 판단
                    // 해당 위치에 자신의 돌, 즉 white을 놓을 때 가중치를 더함
                    stone = STONE.white;
                    for (int j = 0; j < lineCnt; j++)
                    {
                        for (int i = 0; i < lineCnt; i++)
                        {
                            if (board[j, i] != STONE.none) continue;

                            int c5F = 0;  // connect - closed - jump
                            int c5C0T = 0;  // 가중치 임의로 넣음
                            int c5C1T = 0;  // 가중치 임의로 넣음
                            int c5C2T = 0;  // 가중치 임의로 넣음
                            int c4C0F = 0;
                            int c4C1F = 0;
                            int c4C0T = 0;
                            int c4C1T = 0;
                            int c3C0F = 0;
                            int c3C1F = 0;
                            int c3C0T = 0;
                            int c3C1T = 0;
                            int c2C0F = 0;
                            int c2C1F = 0;
                            int c2C0T = 0;
                            int c2C1T = 0;


                            List<WeightInfo> li = new List<WeightInfo>(); // 4방향 확인
                            board[j, i] = stone;  // 연결된 5 뒤에 한 칸 띄고 같은 색이 또 있는 edge case를 제거하기 위해
                            if (checkOmok(board, j, i, stone) == stone)
                            {
                                li.Add(new WeightInfo(5, 0, false));
                            }
                            else
                            {
                                li.Add(checkDir1(j, i, stone));
                                li.Add(checkDir2(j, i, stone));
                                li.Add(checkDir3(j, i, stone));
                                li.Add(checkDir4(j, i, stone));
                            }
                            board[j, i] = STONE.none;

                            foreach (WeightInfo wi in li)
                            {
                                if (wi.connectCnt >= 5 && wi.jump == false) c5F++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 0) c5C0T++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 1) c5C1T++;
                                else if (wi.connectCnt >= 5 && wi.closedCnt == 2) c5C2T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == false) c4C0F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == false) c4C1F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == true) c4C0T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == true) c4C1T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == false) c3C0F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == false) c3C1F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == true) c3C0T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == true) c3C1T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == false) c2C0F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == false) c2C1F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == true) c2C0T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == true) c2C1T++;
                            }

                            // 게임 종료
                            if (c5F >= 1)  // 5목 + 장목
                            {
                                w_board[j, i] += (int)Weight.Gameover;
                                gameover = true;
                                break;
                            }
                            // 필승 카드
                            if (c4C0F >= 1)  // 이어진, 열린 4가 포함됨
                            {
                                w_board[j, i] += (int)Weight.Open4;
                                c4C0F = 0;
                            }
                            else if (c4C1T + c4C1F >= 1 && c3C0F >= 1)  // 한쪽만 닫힌4 + 이어진, 열린3
                            {
                                w_board[j, i] += (int)Weight.Closed4Open3;
                                c4C1T = 0;
                                c4C1F = 0;
                                c3C0F = 0;
                            }
                            else if (c3C0F + c3C0T >= 2)  // 열린 3이 2 개 이상
                            {
                                w_board[j, i] += (int)Weight.OpenNoJump33;
                                c3C0T = 0;
                                c3C0F = 0;
                            }
                            // 가중치 합 필요
                            if ((c4C1T + c4C1F >= 1 && c3C0T >= 1) ||
                                (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)) // 막을 수 있는 43
                            {
                                w_board[j, i] += (int)Weight.NoVictory43;
                                if (c4C1T + c4C1F >= 1 && c3C0T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C0T = 0;
                                }
                                else if (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C1F = 0;
                                    c3C1T = 0;
                                }
                            }
                            if (c4C0T == 1)  // 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c5C0T >= 1)  // 6목이 가능한 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c3C0F + c3C0T == 1 && c2C0F + c2C0T >= 1)  // 열린 32
                            {
                                w_board[j, i] += (int)Weight.Open32;
                                c3C0F = 0;
                                c3C0T = 0;
                                c2C0F = 0;
                                c2C0T = 0;
                            }
                            if (c2C0T + c2C0F >= 3)  // 열린 222
                            {
                                w_board[j, i] += (int)Weight.Open222;
                                c2C0T = 0;
                                c2C0F = 0;
                            }
                            if (c3C0F >= 1)  // 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenNojump3;
                            }
                            if (c3C0T >= 1 || c5C1T >= 1)  // 한 칸 띄어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenJump3;
                            }
                            if (c4C1F >= 1 || c5C2T >= 1)  // 이어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump4;
                            }
                            if (c4C1T >= 1)  // 띄어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedJump4;
                            }
                            if (c3C1T >= 1)  // 띄어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedJump3;
                            }
                            if (c3C1F >= 1)  // 이어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump3;
                            }
                            if (c2C0F >= 1)  // 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenJump2;
                            }
                            if (c2C1F >= 1)  // 닫힌 2
                            {
                                w_board[j, i] += (int)Weight.Closed2;
                            }
                        }
                        if (gameover) break;
                    }
                    if (gameover) break;


                    // 해당 위치에 상대방 돌, 즉 black를 놓을 때 가중치를 더함
                    stone = STONE.black;
                    for (int j = 0; j < lineCnt; j++)
                    {
                        for (int i = 0; i < lineCnt; i++)
                        {
                            if (board[j, i] != STONE.none) continue;
                            if (j > 0 && j < lineCnt - 1 &&
                                i > 0 && i < lineCnt - 1 &&
                                checkForbidden(j, i, board)) continue; // black의 금수 위치
                                                                       // 똑똑한 상대방은  해당 위치에 두지 않는다고 판단

                            int c5 = 0;  // connect - closed - jump
                            int c4C0F = 0;
                            int c4C1F = 0;
                            int c4C0T = 0;
                            int c4C1T = 0;
                            int c3C0F = 0;
                            int c3C1F = 0;
                            int c3C0T = 0;
                            int c3C1T = 0;
                            int c2C0F = 0;
                            int c2C1F = 0;
                            int c2C0T = 0;
                            int c2C1T = 0;

                            List<WeightInfo> li = new List<WeightInfo>(); // 4방향 확인
                            board[j, i] = stone;  // 연결된 5 뒤에 한 칸 띄고 같은 색이 또 있는 edge case를 제거하기 위해
                            if (checkOmok(board, j, i, stone) == stone)
                            {
                                li.Add(new WeightInfo(5, 0, false));
                            }
                            else
                            {
                                li.Add(checkDir1(j, i, stone));
                                li.Add(checkDir2(j, i, stone));
                                li.Add(checkDir3(j, i, stone));
                                li.Add(checkDir4(j, i, stone));
                            }
                            board[j, i] = STONE.none;

                            foreach (WeightInfo wi in li)
                            {
                                if (wi.connectCnt == 5 && wi.jump == false) c5++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == false) c4C0F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == false) c4C1F++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 0 && wi.jump == true) c4C0T++;
                                else if (wi.connectCnt == 4 && wi.closedCnt == 1 && wi.jump == true) c4C1T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == false) c3C0F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == false) c3C1F++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 0 && wi.jump == true) c3C0T++;
                                else if (wi.connectCnt == 3 && wi.closedCnt == 1 && wi.jump == true) c3C1T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == false) c2C0F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == false) c2C1F++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 0 && wi.jump == true) c2C0T++;
                                else if (wi.connectCnt == 2 && wi.closedCnt == 1 && wi.jump == true) c2C1T++;
                            }

                            // 게임 종료
                            if (c5 >= 1)  // 5목  // 11, 3확인
                            {
                                w_board[j, i] += (int)Weight.Gameover;
                                gameover = true;
                                break;
                            }
                            // 필승 카드
                            if (c4C0F >= 1)  // 이어진, 열린 4가 포함됨
                            {
                                w_board[j, i] += (int)Weight.Open4;
                                c4C0F = 0;
                            }
                            else if (c4C1T + c4C1F >= 1 && c3C0F >= 1)  // 한쪽만 닫힌4 + 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.Closed4Open3;
                                c4C1T = 0;
                                c4C1F = 0;
                                c3C0F = 0;
                            }
                            else if (c3C0T >= 1 && c3C0F >= 1)  // 하나는 띄어진, 열린 33
                            {
                                w_board[j, i] += (int)Weight.OpenJump33;
                                c3C0T = 0;
                                c3C0F = 0;
                            }
                            // 가중치 합 필요
                            if ((c4C1T + c4C1F >= 1 && c3C0T >= 1) ||
                                (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)) // 막을 수 있는 43
                            {
                                w_board[j, i] += (int)Weight.NoVictory43;
                                if (c4C1T + c4C1F >= 1 && c3C0T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C0T = 0;
                                }
                                else if (c4C1T + c4C1F >= 1 && c3C1F + c3C1T >= 1)
                                {
                                    c4C1T = 0;
                                    c4C1F = 0;
                                    c3C1F = 0;
                                    c3C1T = 0;
                                }
                            }
                            if (c4C0T == 1)  // 한 칸 띄어진 열린 4
                            {
                                w_board[j, i] += (int)Weight.OpenJump4;
                            }
                            if (c3C0F + c3C0T == 1 && c2C0F + c2C0T >= 1)  // 열린 32
                            {
                                w_board[j, i] += (int)Weight.Open32;
                                c3C0F = 0;
                                c3C0T = 0;
                                c2C0F = 0;
                                c2C0T = 0;
                            }
                            if (c2C0T + c2C0F >= 3)  // 열린 222
                            {
                                w_board[j, i] += (int)Weight.Open222;
                                c2C0T = 0;
                                c2C0F = 0;
                            }
                            if (c3C0F >= 1)  // 이어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenNojump3;
                            }
                            if (c3C0T >= 1)  // 한 칸 띄어진, 열린 3
                            {
                                w_board[j, i] += (int)Weight.OpenJump3;
                            }
                            if (c4C1F >= 1)  // 이어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump4;
                            }
                            if (c4C1T >= 1)  // 띄어진, 닫힌 4
                            {
                                w_board[j, i] += (int)Weight.ClosedJump4;
                            }
                            if (c3C1T >= 1)  // 띄어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedJump3;
                            }
                            if (c3C1F >= 1)  // 이어진, 닫힌 3
                            {
                                w_board[j, i] += (int)Weight.ClosedNojump3;
                            }
                            if (c2C0F >= 1)  // 이어진, 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenNoJump2;
                            }
                            if (c2C0T >= 1)  // 떨어진, 열린 2
                            {
                                w_board[j, i] += (int)Weight.OpenJump2;
                            }
                            if (c2C1F >= 1)  // 닫힌 2
                            {
                                w_board[j, i] += (int)Weight.Closed2;
                            }
                        }
                        if (gameover) break;
                    }
                    break;


                default:  // 에러
                    Console.WriteLine("데이터가 잘못 전달되었습니다.");
                    break;
            }


            // print w_board
            for (int i = 0; i < lineCnt; i++)  // y
            {
                for (int j = 0; j < lineCnt; j++)  // x
                {
                    Console.Write("{0} ", w_board[j, i]);
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            return w_board;
        }

        // AI 알고리즘. return Point or int[2] (X, Y)
        public int[] randomAI(STONE[,] board)
        {
            this.board = board;

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

        public int[] fastAI(STONE[,] board, int stoneCnt)
        {
            this.board = board;

            if (stoneCnt % 2 == 1)
            {
                Random random = new Random();
                int len = board.GetLength(0);
                int AIx, AIy;
                do
                {
                    AIx = random.Next(len);
                    AIy = random.Next(len);
                } while (board[AIx, AIy] != STONE.none);
                Thread.Sleep(1000);

                return new int[2] { AIx, AIy };
            }
            else
                for (int j = 0; j < lineCnt; j++)
                    for (int i = 0; i < lineCnt; i++)
                        if (board[j, i] == STONE.none)
                        {
                            Thread.Sleep(1000);
                            return new int[2] { j, i };
                        }

            return new int[2] { 0, 0 };
        }

        public int[] ruleBasedAI(STONE[,] board, STONE AIColor, int stoneCnt)
        { 
            if (stoneCnt == 0)  // 첫 수는 중앙
            {
                Thread.Sleep(1000);
                return new int[2] { 7, 7 };
            }

            this.board = board;
            int[] result = new int[2] { 0, 0 };
            int maxWeight = -(int)Weight.Gameover;
            int[,] w_board = addWeight(AIColor);

            if ((stoneCnt / 2) % 4 == 0)
            {
                for (int j = 0; j < lineCnt; j++)
                {
                    for (int i = 0; i < lineCnt; i++)
                    {
                        if (w_board[j, i] > maxWeight)
                        {
                            maxWeight = w_board[j, i];
                            result[0] = j;
                            result[1] = i;
                        }
                    }
                }
            }
            else if ((stoneCnt / 2) % 4 == 1)
            {
                for (int j = 0; j < lineCnt; j++)
                {
                    for (int i = lineCnt - 1; i >= 0; i--)
                    {
                        if (w_board[j, i] > maxWeight)
                        {
                            maxWeight = w_board[j, i];
                            result[0] = j;
                            result[1] = i;
                        }
                    }
                }
            }
            else if ((stoneCnt / 2) % 4 == 2)
            {
                for (int j = lineCnt - 1; j >= 0; j--)
                {
                    for (int i = 0; i < lineCnt; i++)
                    {
                        if (w_board[j, i] > maxWeight)
                        {
                            maxWeight = w_board[j, i];
                            result[0] = j;
                            result[1] = i;
                        }
                    }
                }
            }
            else
            {
                for (int j = lineCnt - 1; j >= 0; j--)
                {
                    for (int i = lineCnt - 1; i >= 0; i--)
                    {
                        if (w_board[j, i] > maxWeight)
                        {
                            maxWeight = w_board[j, i];
                            result[0] = j;
                            result[1] = i;
                        }
                    }
                }
            }


            if (board[result[0], result[1]] != STONE.none)
            {
                Console.WriteLine("random did!");
                return randomAI(board);
            }
            else
            {
                Thread.Sleep(500);
                return result;
            }
        }
    }


    struct WeightInfo
    {
        public int connectCnt;
        public int closedCnt;
        public bool jump;

        public WeightInfo(int connectCnt, int closedCnt, bool jump)
        {
            this.connectCnt = connectCnt;
            this.closedCnt = closedCnt;
            this.jump = jump;
        }
    }

    enum Weight
    {
        Gameover = 50000,
        Open4 = 10000,
        Closed4Open3 = 8000,
        OpenJump33 = 4600,
        OpenNoJump33 = 4500,
        NoVictory43 = 800,
        OpenJump4 = 660,
        Open32 = 420,
        Open222 = 410,
        OpenNojump3 = 400,
        OpenJump3 = 360,
        ClosedNojump4 = 200,
        ClosedJump4 = 190,
        ClosedJump3 = 120,
        ClosedNojump3 = 60,
        OpenNoJump2 = 50,
        OpenJump2 = 30,  // 40 이었음
        Closed2 = 20     // 30 이었음
    }
}



// 이전 금수체크 알고리즘 (33, 44에 대한 정의 차이 때문에)
/*
 * public bool checkForbidden(int x, int y, STONE[,] board)
        {
            this.board = board;
            this.board[x, y] = STONE.black;  // 해당 빈 공간이 검정돌일 때를 가정

            List<Point> axisList = checkOpenDir1(x, y);
            if (axisList.Count == 3) // 33 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir2(p.X, p.Y).Count == 3) ||
                        (checkOpenDir3(p.X, p.Y).Count == 3) ||
                        (checkOpenDir4(p.X, p.Y).Count == 3))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir2(p.X, p.Y).Count == 4) ||
                        (checkOpenDir3(p.X, p.Y).Count == 4) ||
                        (checkOpenDir4(p.X, p.Y).Count == 4))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }

            axisList = checkOpenDir2(x, y);
            if (axisList.Count == 3) // 33 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 3) ||
                        (checkOpenDir3(p.X, p.Y).Count == 3) ||
                        (checkOpenDir4(p.X, p.Y).Count == 3))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 4) ||
                        (checkOpenDir3(p.X, p.Y).Count == 4) ||
                        (checkOpenDir4(p.X, p.Y).Count == 4))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }

            axisList = checkOpenDir3(x, y);
            if (axisList.Count == 3) // 33 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 3) ||
                        (checkOpenDir2(p.X, p.Y).Count == 3) ||
                        (checkOpenDir4(p.X, p.Y).Count == 3))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 4) ||
                        (checkOpenDir2(p.X, p.Y).Count == 4) ||
                        (checkOpenDir4(p.X, p.Y).Count == 4))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }

            axisList = checkOpenDir4(x, y);
            if (axisList.Count == 3) // 33 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 3) ||
                        (checkOpenDir2(p.X, p.Y).Count == 3) ||
                        (checkOpenDir3(p.X, p.Y).Count == 3))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }
            else if (axisList.Count == 4) // 44 check
            {
                foreach (Point p in axisList)
                {
                    if ((checkOpenDir1(p.X, p.Y).Count == 4) ||
                        (checkOpenDir2(p.X, p.Y).Count == 4) ||
                        (checkOpenDir3(p.X, p.Y).Count == 4))
                    {
                        this.board[x, y] = STONE.none;
                        return true;
                    }
                }
            }

            this.board[x, y] = STONE.none;
            return false;
        }
*/