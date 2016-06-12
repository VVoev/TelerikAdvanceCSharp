
using System;
using System.Collections.Generic;
using System.Linq;

public class ChampionsLeague
    {
    public static void Main()
    {
        //   int n = int.Parse(Console.ReadLine());
        // int rows = int.Parse(Console.ReadLine());
        //int cols = int.Parse(Console.ReadLine());
        //   int[,] matrix = SpiralMatrix(n);
        //int[,] matrix = BottomToTopMatrix(rows, cols);
        //int[,] matrix = ReverseVerticalMatrix(rows, cols);
        //int[,] matrix = VerticalMatrix(rows, cols);
        //int[,] matrix = NormalMatrix(rows, cols);
        //  PrintMatrix(rows, cols, matrix);
        //   PrintMatrixSFromN(n, matrix);
       // SnakeMatrix();
    }

    //private static void SnakeMatrix()
    //{
    //    for (int r = rols - 1; r >= 0; r--)
    //    {
    //        if (direction % 2 != 0)
    //        {
    //            for (int c = cols - 1; c >= 0; c--)
    //            {
    //                matrix[r, c] = text[counter % text.Length];
    //                counter++;
    //            }                                                                     13 14 15 16
    //            direction++;                                                          12 11 10 9
    //        }                                                                         5  6  7 8
    //        else                                                                      4  3 2 1
    //        {
    //            for (int c = 0; c < cols; c++)
    //            {
    //                matrix[r, c] = text[counter % text.Length];
    //                counter++;
    //            }
    //            direction++;
    //        }
    //    }
    //}

    private static void PrintMatrixSFromN(int n, int[,] matrix)
    {
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                Console.Write("{0,3}", matrix[r, c]);
            }
            Console.WriteLine();
        }
    }
    private static int[,] SpiralMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        int row = 0;                                              /* 1   2  3  4*/
        int col = 0;                                              /* 12  13 14 5*/
        string direction = "right";                               /* 11  16 15 6*/
        int maxRotations = n * n;                                 /* 10  9  8  7*/

        for (int i = 1; i <= maxRotations; i++)
        {
            if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
            {
                direction = "down";
                col--;
                row++;
            }
            if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
            {
                direction = "left";
                row--;
                col--;
            }
            if (direction == "left" && (col < 0 || matrix[row, col] != 0))
            {
                direction = "up";
                col++;
                row--;
            }

            if (direction == "up" && row < 0 || matrix[row, col] != 0)
            {
                direction = "right";
                row++;
                col++;
            }

            matrix[row, col] = i;

            if (direction == "right")
            {
                col++;
            }
            if (direction == "down")
            {
                row++;
            }
            if (direction == "left")
            {
                col--;
            }
            if (direction == "up")
            {
                row--;
            }
        }
        return matrix;
    }
    private static int[,] BottomToTopMatrix(int rows, int cols)
    {
        int a = 0; int[,] matrix = new int[rows, cols];
        for (int col = cols-1; col >=0; col--)
        {
            for (int row = 0; row < rows; row++)                          /*13 14 15 16*/
            {                                                             /*9  10 11 12*/
                matrix[col, row] = a;                                     /*5  6  7  8*/
                a++;                                                      /*1  2  3  4*/
            }
        }
        return matrix;
    }
    private static void PrintMatrix(int rows, int cols, int[,] matrix)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    private static int[,] ReverseVerticalMatrix(int rows, int cols)
    {
        int a = 1;int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            if (row % 2 == 0)                                   /*1  8  9   16*/
            {                                                   /*2  7  10  15*/
                for (int col = 0; col < cols; col++)            /*3  6  11  14*/
                {                                               /*4  5  12  13*/
                    matrix[col, row] = a;
                    a++;
                }
            }
            else
            {
                for (int col = cols-1; col>=0; col--)
                {
                    matrix[col, row] = a;
                    a++;
                }
            }
        }
        return matrix;
    }
    private static int[,] VerticalMatrix(int rows, int cols)
    {
        int a = 1;
        int [,]matrix = new int[rows, cols];                    /*1  5  9   13*/
        for (int row = 0; row < cols; row++)                    /*2  6  10  14*/
        {                                                       /*3  7  11  15*/
            for (int col = 0; col < rows; col++)                /*4  8  12  16*/
            {
                matrix[col, row] = a;a++;
            }
        }
        return matrix;
    }
    private static int[,] NormalMatrix(int rows, int cols)
    {
        int a = 1;
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
               // Console.Write("Enter value for ({0},{1}): ", i, j);
                matrix[row, col] = a;a++;
            }
        }
        return matrix;
    }
}