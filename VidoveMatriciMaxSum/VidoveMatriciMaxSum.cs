using System;
using System.Collections.Generic;
using System.Linq;
    class VidoveMatriciMaxSum
    { 
    
        static void Main()
        {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int[,] sum = new int[x, y];
        int result = 0;
        int bestresult = 0;
        for (int row = 0; row < rows-x-1; row++)
        {
            for (int col = 0; col < cols-y-1; col++)
            {
                result = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (result > bestresult)
                    bestresult = result;
            }
        }
        Console.WriteLine(bestresult);
    }
    }