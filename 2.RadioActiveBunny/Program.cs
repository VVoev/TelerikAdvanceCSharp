using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] matrixDimensions =Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int rols = matrixDimensions[0]; int cols = matrixDimensions[1];
        char[,] bunnyMatrix = new char[matrixDimensions[0], matrixDimensions[1]];
        int pRow = 0; int pCol = 0;
        for (int r = 0; r < rols; r++)
        {
            string comand = Console.ReadLine();
            for (int c = 0; c < cols; c++)
            {
                bunnyMatrix[r, c] = comand[c];                //filling the matrix with Chars
                if(bunnyMatrix[r,c]=='P')
                {
                    pRow = r;
                    pCol = c;
                }
            }
        }
        string directions = Console.ReadLine();
        for (int move = 0; move < directions.Length; move++)
        {
            char comand = directions[move];
            int OLDPlayerRow = pRow; int OldPlayerCol = pCol;

            switch (comand)
            {
                case 'U': pRow--; break;
                case 'D': pRow++; break;
                case 'L': pCol--; break;
                case 'R': pCol++; break;
            }
            if (pRow < 0 || pRow >= rols ||
                pCol < 0 || pCol >= cols)
            {
                for (long row = 0; row < bunnyMatrix.GetLength(0); row++)
                {
                    for (long col = 0; col < bunnyMatrix.GetLength(1); col++)
                    {
                        Console.Write(bunnyMatrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Won {0} {1}",OLDPlayerRow,OldPlayerCol);
            }
            else
            {
                bunnyMatrix[pRow, pCol] = 'P';
                bunnyMatrix[OLDPlayerRow, OldPlayerCol] = '.';
            }
            for (int row = 0; row < rols; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(bunnyMatrix[row,col]=='B')
                    {
                        if (row > 0)
                        {
                            bunnyMatrix[row - 1, col] = 'B';
                            if (bunnyMatrix[row - 1, col] == bunnyMatrix[pRow, pCol])
                            {
                                Console.WriteLine("dead {0} {1}", pRow, pCol);
                                return;
                            }
                        }
                        if (row < rols - 1)
                        {
                            bunnyMatrix[row + 1, col] = 'B';
                            if (bunnyMatrix[row + 1, col] == bunnyMatrix[pRow, pCol])
                            {
                                Console.WriteLine("dead {0} {1}", pRow, pCol);
                                return;
                            }
                        }

                        if (col > 0)
                        {
                            bunnyMatrix[row, col - 1] = 'B';
                            if (bunnyMatrix[row, col - 1] == bunnyMatrix[pRow, pCol])
                            {
                                Console.WriteLine("dead {0} {1}", pRow, pCol);
                                return;
                            }
                        }
                        if (col < cols - 1)
                        {
                            bunnyMatrix[row, col + 1] = 'B';
                            if (bunnyMatrix[row, col + 1] == bunnyMatrix[pRow, pCol])
                            {
                                Console.WriteLine("dead {0} {1}", pRow, pCol);
                                return;
                            }
                        }
                    }
                }
            }
        }


    }

    }
