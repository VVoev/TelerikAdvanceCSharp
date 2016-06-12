using System;
using System.Collections.Generic;
using System.Linq;
    class Program
    {        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, rows];
            for (int r = 0; r < rows; r++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                for (int c = 0; c < rows; c++)
                {

                    matrix[r, c] = int.Parse(input[c]);
                }
            }


        int counter = 0;int sum = 0; bool exist = false; int bestsum = int.MinValue;
        for (int r = 0; r <rows-2; r++)
        {
            for (int c = 0; c < rows-4; c++)
            {                 //1-2                                2-3                                                   3-4
                if (matrix[r, c]-matrix[r, c + 1]==-1  &&   matrix[r, c + 1]-matrix[r, c + 2]==-1 &&matrix[r, c + 2]-matrix[r+1, c + 2]==-1)
                {               //4

                    if (matrix[r+1,c+2]-matrix[r+2,c+2]==-1)
                    {
                        if (matrix[r + 2, c + 2] - matrix[r + 2, c + 3] == -1 && matrix[r + 2, c + 3] - matrix[r + 2, c + 4] == -1)
                        {
                            exist = true;
                            counter++;
                            sum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2] + matrix[r + 1, c + 2] + matrix[r + 2, c + 2] + matrix[r + 2, c + 3] + matrix[r + 2, c + 4];
                            if (sum>bestsum)
                            {
                                bestsum = sum;sum = 0;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(counter);
        Console.WriteLine(bestsum);
        if (!exist)
        {
            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine(sum);
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < rows; c++)
            {
                Console.Write("{0,4}", matrix[r, c]);
            }
            Console.WriteLine();
        }
    }
}
