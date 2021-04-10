using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            int[,] matrix = new int[n, m];

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < m; cols++)
                {
                    matrix[rows, cols] = default;
                }
            }

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] nums = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowBloom = nums[0];
                int colBloom = nums[1];

                if (!InvalidCoordinates(rowBloom, colBloom, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }

                matrix[rowBloom, colBloom]++;

                matrix[rowBloom, colBloom] = BloomUp(rowBloom, colBloom, matrix);
                matrix[rowBloom, colBloom] = BloomDown(rowBloom, colBloom, matrix);
                matrix[rowBloom, colBloom] = BloomLeft(rowBloom, colBloom, matrix);
                matrix[rowBloom, colBloom] = BloomRight(rowBloom, colBloom, matrix);


                input = Console.ReadLine();
            }

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < m; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool InvalidCoordinates(int row, int col, int rows, int cols)
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

        public static int BloomUp(int row, int col, int[,] matrix)
        {
            while (row > 0)
            {
                matrix[row, col] = matrix[row--, col];
                matrix[row, col]++;
            }
            return matrix[row, col];
        }
        public static int BloomDown(int row, int col, int[,] matrix)
        {
            while (row < matrix.GetLength(0) - 1)
            {
                matrix[row, col] = matrix[row++, col];
                matrix[row, col]++;
            }
            return matrix[row, col];
        }
        public static int BloomLeft(int row, int col, int[,] matrix)
        {
            while (col > 0)
            {
                matrix[row, col] = matrix[row, col--];
                matrix[row, col]++;
            }
            return matrix[row, col];
        }
        public static int BloomRight(int row, int col, int[,] matrix)
        {
            while (col < matrix.GetLength(1) - 1)
            {
                matrix[row, col] = matrix[row, col++];
                matrix[row, col]++;
            }
            return matrix[row, col];
        }
    }
}
