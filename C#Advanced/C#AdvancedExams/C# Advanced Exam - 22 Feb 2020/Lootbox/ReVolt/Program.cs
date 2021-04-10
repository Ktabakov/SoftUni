using System;

namespace ReVolt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int comands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            bool markReached = false;

            int lastPositionRow = 0;
            int lastPositionCol = 0;

            int positionRow = 0;
            int positionCol = 0;

            for (int rows = 0; rows < n; rows++)
            {
                string input = Console.ReadLine();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (matrix[rows, cols] == 'f')
                    {
                        positionRow = rows;
                        positionCol = cols;

                        lastPositionRow = rows;
                        lastPositionCol = cols;
                    }
                }
            }

            for (int i = 0; i < comands; i++)
            {
                string movement = Console.ReadLine();

                if (matrix[positionRow, positionCol] == '-' || matrix[positionRow, positionCol] == 'f')
                {
                    matrix[positionRow, positionCol] = '-';
                }

                lastPositionRow = positionRow;
                lastPositionCol = positionCol;

                positionRow = MoveRow(positionRow, movement);
                positionCol = MoveCol(positionCol, movement);

                positionRow = IsRowValid(positionRow, n);
                positionCol = IsColValid(positionCol, n);

                if (matrix[positionRow, positionCol] == 'B')
                {
                    positionRow = MoveRow(positionRow, movement);
                    positionCol = MoveCol(positionCol, movement);

                    positionRow = IsRowValid(positionRow, n);
                    positionCol = IsColValid(positionCol, n);
                }
                else if (matrix[positionRow, positionCol] == 'T')
                {
                    positionRow = lastPositionRow;
                    positionCol = lastPositionCol;
                }

                if (matrix[positionRow, positionCol] == 'F')
                {
                    matrix[positionRow, positionCol] = 'f';
                    markReached = true;
                    break;
                }
                matrix[positionRow, positionCol] = 'f';
            }

            if (markReached)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }

        }
        public static int IsRowValid(int row, int rows)
        {
            if (row < 0)
            {
                row = rows - 1;
            }
            else if (row >= rows)
            {
                row = 0;
            }
            return row;
        }
        public static int IsColValid(int col, int cols)
        {
            if (col < 0)
            {
                col = cols - 1;
            }
            else if (col >= cols)
            {
                col = 0;
            }
            return col;
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
