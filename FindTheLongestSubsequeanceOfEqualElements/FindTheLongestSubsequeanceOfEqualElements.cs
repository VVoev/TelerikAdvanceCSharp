using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheLongestSubsequeanceOfEqualElements
{
    class Program
    {
        static string[,] matrix;

        static void Main(string[] args)
        {
            // Initialize the matrix
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            matrix = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] transformation = input.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = transformation[j];
                }

            }

            // Find the longest sequence of equal strings
            SortedDictionary<string, int> sequence = new SortedDictionary<string, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int neighbourCount = LookupNeighbours(row, col);
                    if (neighbourCount == 0)
                    {
                        if (sequence.ContainsKey(matrix[row, col]))
                        {
                            sequence.Remove(matrix[row, col]);
                        }
                    }
                    else
                    {
                        if (sequence.ContainsKey(matrix[row, col]))
                        {
                            sequence[matrix[row, col]]++;
                        }
                        else
                        {
                            sequence.Add(matrix[row, col], 1);
                        }
                    }
                }
              }
            sequence.OrderBy(x => x.Value);

        }

            

        private static int LookupNeighbours(int x, int y)
        {
            int result = 0;
            for (int row = x - 1; row <= x + 1; row++)
            {
                if (row < 0 || row > matrix.GetLength(0) - 1)
                {
                    continue;
                }
                for (int col = y - 1; col <= y + 1; col++)
                {
                    if (col < 0 || col > matrix.GetLength(1) - 1 || (row == x && col == y))
                    {
                        continue;
                    }
                    if (matrix[row, col] == matrix[x, y])
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
