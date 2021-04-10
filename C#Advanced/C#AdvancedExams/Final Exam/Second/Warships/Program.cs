using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalCountShipsDestroyed = 0;

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            char[,] matrix = new char[n, n];

            string[] coordiantes = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int rows = 0; rows < n; rows++)
            {
                char[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int cols = 0; cols < currentRow.Length; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                    if (matrix[rows, cols] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[rows, cols] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < coordiantes.Length; i++)
            {
                int[] currentCoordinates = coordiantes[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = currentCoordinates[0];
                int col = currentCoordinates[1];

                if (IsGameOver(firstPlayerShips, secondPlayerShips))
                {
                    break;
                }

                if (!IsPositionValid(row, col, n, n))
                {
                    continue;
                }

                if (matrix[row, col] == '<')
                {
                    matrix[row, col] = 'X';
                    firstPlayerShips--;
                    totalCountShipsDestroyed++;

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                }
                else if (matrix[row, col] == '>')
                {
                    matrix[row, col] = 'X';
                    secondPlayerShips--;
                    totalCountShipsDestroyed++;

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                }
                else if (matrix[row, col] == '*')
                {
                    continue;
                }
                else if(matrix[row, col] == '#')
                {
                    matrix[row, col] = 'X';
                    int lenght = matrix.GetLength(0);

                    if (IsPositionValid(row + 1, col, lenght, lenght))
                    {
                        if (matrix[row + 1, col] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row + 1, col] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row + 1, col] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                    if (IsPositionValid(row - 1, col, lenght, lenght))
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row - 1, col] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row - 1, col] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                    if (IsPositionValid(row, col - 1, lenght, lenght))
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row, col - 1] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row, col - 1] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                    if (IsPositionValid(row, col + 1, lenght, lenght))
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row, col + 1] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row, col + 1] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                    if (IsPositionValid(row + 1, col + 1, lenght, lenght))
                    {
                        if (matrix[row + 1, col + 1] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row + 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row + 1, col + 1] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }

                    if (IsPositionValid(row -1, col - 1, lenght, lenght))
                    {
                        if (matrix[row - 1, col - 1] == '<')
                        {
                            firstPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        else if (matrix[row - 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                            totalCountShipsDestroyed++;
                        }
                        matrix[row - 1, col - 1] = 'X';
                    }

                    if (IsGameOver(firstPlayerShips, secondPlayerShips))
                    {
                        break;
                    }
                }
            }

            if(firstPlayerShips > 0 && secondPlayerShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (secondPlayerShips > 0 && firstPlayerShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
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
        public static bool IsGameOver(int firstPlayerShips, int secondPlayerShips)
        {
            if (firstPlayerShips<= 0 || secondPlayerShips <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
