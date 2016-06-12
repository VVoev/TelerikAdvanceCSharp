using System;
using System.Linq;
class CheckingForNeighbourinMatrix
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = input[0];
        int cols = input[1];
        var matrix = FillMatrix(rows, cols);
        int counter = 1;
        int bestcounter = 1;
        CheckingVertical(rows, cols, matrix, ref counter, ref bestcounter);
        CheckingHorizontal(rows, cols, matrix, ref counter, ref bestcounter);
        CheckingLeftRightDiagonal(rows, cols, matrix, ref counter, ref bestcounter);
        CheckingRightLeftDiagonal(rows, cols, matrix, ref counter, ref bestcounter);
        Console.WriteLine(bestcounter);
    }

    private static void CheckingRightLeftDiagonal(int rows, int cols, int[,] matrix, ref int counter, ref int bestcounter)
    {
        int startRow = 0;
        int StartCol = 0;
        for (int r = 0; r <rows; r++)
        {
            for (int c = cols; c >= 0; c--)
            {
                startRow = r;
                StartCol = c-1;
                while (startRow < rows-1 && StartCol > 0)
                {
                    if (matrix[startRow, StartCol] == matrix[startRow + 1, StartCol - 1])
                    {
                        counter++;
                        startRow++;
                        StartCol--;
                    }
                    else
                    {
                        startRow++;
                        StartCol--;
                    }
                }
                if (counter > bestcounter)
                {
                    bestcounter = counter;
                }
                counter = 1;
            }
        }
    }

    private static int CheckingLeftRightDiagonal(int rows, int cols, int[,] matrix, ref int counter, ref int bestcounter)
    {
        int startRow = 0;
        int StartCol = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                startRow = r;
                StartCol = c;
                while (startRow < rows - 1 && StartCol < cols - 1)
                {
                    if (matrix[startRow, StartCol] == matrix[startRow + 1, StartCol + 1])
                    {
                        counter++;
                        startRow++;
                        StartCol++;
                    }
                    else
                    {
                        startRow++;
                        StartCol++;
                    }
                }
                if (counter > bestcounter)
                {
                    bestcounter = counter;
                }
                counter = 1;
            }
        }
        return counter;
    }

    private static int CheckingHorizontal(int rows, int cols, int[,] matrix, ref int counter, ref int bestcounter)
    {
        int startRow = 0;
        int StartCol = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                startRow = r;
                StartCol = c;
                while (startRow < rows - 1)
                {
                    if (matrix[startRow, StartCol] == matrix[startRow + 1, StartCol])
                    {
                        counter++;
                        startRow++;
                    }
                    else
                    {
                        startRow++;
                    }
                }
                if (counter > bestcounter)
                {
                    bestcounter = counter;
                }
                counter = 1;
            }
        }
        return bestcounter;
    }

    private static int CheckingVertical(int rows, int cols, int[,] matrix, ref int counter, ref int bestcounter)
    {
        int startRow = 0;
        int StartCol = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                startRow = r;
                StartCol = c;
                while (StartCol < cols - 1)
                {
                    if (matrix[startRow, StartCol] == matrix[startRow, StartCol + 1])
                    {
                        counter++;
                        StartCol++;
                    }
                    else
                    {
                        StartCol++;
                    }
                }
                if (counter > bestcounter)
                {
                    bestcounter = counter;
                }
                counter = 1;
            }
        }
        return bestcounter;
    }

    private static int[,]FillMatrix(int rows, int cols)
    {
        var matrix = new int[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            var comand = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = comand[c];
            }
        }
        return matrix;
    }
}