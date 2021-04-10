using System;
using System.Linq;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;

            int flowersCount = 0;

            for (int rows = 0; rows < n; rows++)
            {
                string currentRow = Console.ReadLine();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                    if (matrix[rows, cols] == 'B')
                    {
                        beeRow = rows;
                        beeCol = cols;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!IsValidIndex(beeRow, beeCol, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowersCount++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!IsValidIndex(beeRow, beeCol, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowersCount++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';
              command = Console.ReadLine();
            }

            if (flowersCount >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5- flowersCount} flowers more");
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

        private static int MoveCol(int beeCol, string command)
        {
            if (command == "left")
            {
                beeCol -= 1;
            }
            else if (command == "right")
            {
                beeCol += 1;
            }
            return beeCol;
        }

        private static int MoveRow(int beeRow, string command)
        {
            if (command == "up")
            {
                beeRow -= 1;
            }
            else if (command == "down")
            {
                beeRow += 1;
            }
            return beeRow;
        }

        public static bool IsValidIndex(int row, int col, int lenght)
        {
            if (row < 0 || row >= lenght || col < 0 || col >= lenght)
            {
                return false;
            }

            return true;
        }
    }
}
