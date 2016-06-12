using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
class LoverOfThree
{
    static void Main()
    {
        string[] matrixFrame = Console.ReadLine().Split(' ').ToArray();
        int row = int.Parse(matrixFrame[0]);
        int col = int.Parse(matrixFrame[1]);
        int numberOfMatrixMoves = int.Parse(Console.ReadLine());
        //int max = row * col;
        int[,] matrix = new int[row, col];
        FillDiagonalMatrixWithStep3(row, col, matrix);
       
        int result = 0;
        int startRow = row - 1;
        int startCol = 0;
        for (int i = 0; i <= numberOfMatrixMoves - 1; i++)
        {
            string[] command = Console.ReadLine().ToUpper().Split(' ').ToArray();
            string direction = command[0];
            int moves = int.Parse(command[1]);
            while (moves > 1)
            {
               
                if (direction.Contains("UR") || direction.Contains("RU"))
                {
                    startCol++;
                    startRow--;
                    if (startCol > col - 1 || startRow < 0)
                    {
                        startCol--;
                        startRow++;
                        break;
                    }
                }
                else if (direction.Contains("UL") || direction.Contains("LU"))
                {
                    startCol--;
                    startRow--;
                    if (startCol < 0 || startRow < 0)
                    {
                        startCol++;
                        startRow++;
                        break;
                    }
                }
                else if (direction.Contains("LD") || direction.Contains("DL"))
                {
                    startCol--;
                    startRow++;
                    if (startCol < 0 || startRow > row - 1)
                    {
                        startCol++;
                        startRow--;
                        break;
                    }
                }
                else if (direction.Contains("DR") || direction.Contains("RD"))
                {
                    startCol++;
                    startRow++;
                    if (startCol > col - 1 || startRow > row - 1)
                    {
                        startCol--;
                        startRow--;
                        break;
                    }
                }
                int value = matrix[startRow, startCol];
                result += value;
                matrix[startRow, startCol] = 0;
                moves--;
            }
           
           
            //PrintMatrix(row, col, matrix);
        }
        Console.WriteLine(result);
    }
 
    static void PrintMatrix(int row, int col, int[,] matrix)
    {
        for (int rows = 0; rows < row; rows++)
        {
            for (int cols = 0; cols < col; cols++)
            {
                Console.Write("{0,4}", matrix[rows, cols]);
            }
            Console.WriteLine();
        }
    }
 
    static void FillDiagonalMatrixWithStep3(int row, int col, int[,] matrix)
    {
        int r = 0;
        int c = 0;
        int number = 0;
        // Fill the down diagonal matrix. Start from last row and column 0.
        for (int i = row - 1; i >= 0; i--, number += 3)
        {
            r = i;
            c = 0;
            while (r < row && c < col)
            {
                matrix[r, c] = number;
 
                r++;
                c++;
            }
 
        }
        //Fill upper diagonal matrix. Start from row 0 and column 1.
        for (int j = 1; j <= col; j++, number += 3)
        {
            r = 0;
            c = j;
            while (r < row && c < col)
            {
                matrix[r, c] = number;
                r++;
                c++;
            }
        }
        //for (int rows = 0; rows < row; rows++)
        //{
        //    for (int cols = 0; cols < col; cols++)
        //    {
        //        Console.Write("{0,4}", matrix[rows, cols]);
        //    }
        //    Console.WriteLine();
        //}
    }
}