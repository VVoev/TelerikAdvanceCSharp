using System;
using System.Collections.Generic;
using System.Linq;
class TargetPractiseMatrix
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int counter = 0;
        int direction = 1;
        int rols = input[0]; int cols = input[1];
        string text = Console.ReadLine();
        char[,] matrix = new char[rols, cols];
        FillingMatrixInSnakeDirection(ref counter, ref direction, rols, cols, text, matrix);
        var ShotArea = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int bombX = ShotArea[0];
        int bombY = ShotArea[1];
        int Radius = ShotArea[2];
        long startRow = Math.Max(0, bombX - 1);
        long endRow = Math.Min(matrix.GetLength(0) - 1, bombX + 1);
        long startCol = Math.Max(0, bombY - 1);
        long endCol = Math.Min(matrix.GetLength(1) - 1, bombY + 1);
        char sum = ' ';

        for (long row = startRow; row <= endRow; row++)
        {
            for (long col = startCol; col <= endCol; col++)
            {
                if (!(bombX == row && bombY == col))
                {
                    matrix[row, col] = sum;
                }
                else
                    matrix[row, col] = sum;
            }
        }


        RadiusChecking(rols, cols, matrix, bombX, bombY, Radius, sum);
        int width = matrix.GetLength(0);

        for (int row = rols - 1; row >= 0; row--)
        {
            for (int column = 0; column < cols; column++)
            {
                if (matrix[row,column] != ' ')
                {
                    continue;
                }

                int currentRow = row - 1;
                while (currentRow >= 0)
                {
                    if (matrix[currentRow,column] != ' ')
                    {
                        matrix[row,column] = matrix[currentRow,column];
                        matrix[currentRow,column] = ' ';
                        break;
                    }

                    currentRow--;
                }
            }
        }
        PrintingMatrix(rols, cols, matrix);
    }

    private static void RadiusChecking(int rols, int cols, char[,] matrix, int bombX, int bombY, int Radius, char sum)
    {
        if (bombX + Radius <= rols)
            matrix[bombX + Radius, bombY] = sum;
        if (bombX - Radius >= 0)
            matrix[bombX - Radius, bombY] = sum;
        if (bombY + Radius <= cols)
            matrix[bombX, bombY + Radius] = sum;
        if (bombY - Radius >= 0)
            matrix[bombX, bombY - Radius] = sum;
    }

    private static void PrintingMatrix(int rols, int cols, char[,] matrix)
    {
        for (int r = 0; r < rols; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write("{0,3}", matrix[r, c]);
            }
            Console.WriteLine();
        }
    }

    private static void FillingMatrixInSnakeDirection(ref int counter, ref int direction, int rols, int cols, string text, char[,] matrix)
    {
        for (int r = rols - 1; r >= 0; r--)
        {
            if (direction % 2 != 0)
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    matrix[r, c] = text[counter % text.Length];
                    counter++;
                }
                direction++;
            }
            else
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = text[counter % text.Length];
                    counter++;
                }
                direction++;
            }
        }
    }
}