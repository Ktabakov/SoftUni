using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nums[0];
            int m = nums[1];

            Dictionary<int, int> allFours = new Dictionary<int, int>();

            int[,] matrix = new int[n, m];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = 0;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                string[] coordinates = command.Split().ToArray();

                int inputRow = int.Parse(coordinates[0]);
                int inputCol = int.Parse(coordinates[1]);

                if (!IsPositionValid(inputRow, inputCol, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                allFours.Add(inputRow, inputCol);
            }

            foreach (var flour in allFours)
            {
                int r = flour.Key;
                int c = flour.Value;

                matrix[r, c] += 1;

                matrix = bloomUp(matrix, r, c);
                matrix = bloomDown(matrix, r, c);
                matrix = bloomLeft(matrix, r, c);
                matrix = bloomRight(matrix, r, c);
            }


            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(string.Join(" ", matrix[r, c] + " "));
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

        public static int[,] bloomUp(int[,] matrix, int r, int c)
        {
            r--;
            while (r >= 0)
            {
                matrix[r, c] += 1;
                r--;
            }
            return matrix;
        }
        public static int[,] bloomDown(int[,] matrix, int r, int c)
        {
            r++;
            while (r < matrix.GetLength(0))
            {
                matrix[r, c] += 1;
                r++;
            }
            return matrix;
        }
        public static int[,] bloomLeft(int[,] matrix, int r, int c)
        {
            c--;
            while (c >= 0)
            {
                matrix[r, c] += 1;
                c--;
            }
            return matrix;
        }
        public static int[,] bloomRight(int[,] matrix, int r, int c)
        {
            c++;
            while (c < matrix.GetLength(1))
            {
                matrix[r, c] += 1;
                c++;
            }
            return matrix;
        }
    }
}
