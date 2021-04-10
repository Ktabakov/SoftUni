using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int allMoney = 0;
            bool outOfBakery = false;

            int myPostionRow = 0;
            int myPositionCol = 0;

            for (int rows = 0; rows < n; rows++)
            {
                string input = Console.ReadLine();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (matrix[rows, cols] == 'S')
                    {
                        myPostionRow = rows;
                        myPositionCol = cols;
                    }
                }
            }

            while (allMoney < 50)
            {
                string command = Console.ReadLine();

                matrix[myPostionRow, myPositionCol] = '-';

                myPostionRow = MoveRow(myPostionRow, command);
                myPositionCol = MoveCol(myPositionCol, command);

                if (!IsPositionValid(myPostionRow, myPositionCol, n, n))
                {
                    outOfBakery = true;
                    break;
                }

                if (matrix[myPostionRow, myPositionCol] != 'O' && matrix[myPostionRow, myPositionCol] != '-')
                {
                    char charNum = matrix[myPostionRow, myPositionCol];
                    int num = int.Parse(charNum.ToString());
                    allMoney += num;
                }
                if (matrix[myPostionRow, myPositionCol] == 'O')
                {
                    matrix[myPostionRow, myPositionCol] = '-';
                    for (int r = 0; r < n; r++)
                    {
                        for (int c = 0; c < n; c++)
                        {
                            if (matrix[r, c] == 'O')
                            {
                                myPostionRow = r;
                                myPositionCol = c;
                            }
                        }
                    }
                    matrix[myPostionRow, myPositionCol] = '-';
                }

                if (myPostionRow == n - 1 && myPositionCol == n - 1)
                {
                    outOfBakery = true;
                    break;
                }
                matrix[myPostionRow, myPositionCol] = 'S';

            }
            if (outOfBakery || allMoney < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else if (allMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {allMoney}");

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c  < n; c ++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
