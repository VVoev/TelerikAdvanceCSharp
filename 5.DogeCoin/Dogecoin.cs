using System;
using System.Collections.Generic;
using System.Linq;
class Dogecoin
{
    static void Main()
    {
        //input
        var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];
        int[,] coins = new int[rows, cols];
        int TotalCellWithCoins = int.Parse(Console.ReadLine());
        //puting coins on a console position
        for (int i = 0; i < TotalCellWithCoins; i++)
        {
            var currectdorinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currentCoinRow = currectdorinates[0];
            int currentCoinCol = currectdorinates[1];

            coins[currentCoinRow, currentCoinCol]++;
        }
        //Algorithm - will take the maximum value and draging it back to the exit
        int[,] dinamicPrograming = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int maxAbove = 0;
                int maxLEft = 0;
                if(row-1>=0)
                {
                    maxAbove = dinamicPrograming[row - 1, col];
                }
                if(col-1>=0)
                {
                    maxLEft = dinamicPrograming[row, col - 1];
                }
                dinamicPrograming[row, col] = Math.Max(maxAbove, maxLEft) + coins[row, col];
            }
        }
        Console.WriteLine(dinamicPrograming[rows-1,cols-1]);
    }
}
