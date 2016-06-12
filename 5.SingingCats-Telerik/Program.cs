using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.Bit_shift_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger rows = int.Parse(Console.ReadLine());
            BigInteger cols = int.Parse(Console.ReadLine());
            BigInteger movesAmount = int.Parse(Console.ReadLine());
            BigInteger[] directions = Console.ReadLine().Split(' ').Select(x => BigInteger.Parse(x)).ToArray();
            BigInteger[,] matrix = new BigInteger[(ulong)rows, (ulong)cols];
            BigInteger max = BigInteger.Max(rows, cols);
            List<BigInteger> rowsOfThePawn = new List<BigInteger>();
            List<BigInteger> colsOfThePawn = new List<BigInteger>();
            for (int i = 0; i<directions.Length; i++)
            {
                rowsOfThePawn.Add(directions[i] / max);
                colsOfThePawn.Add(directions[i] % max);
            }
            //Filling matrix
            BigInteger current = 1;
            for (BigInteger rowz = matrix.GetLength(0) - 1; rowz >= 0; rowz--)
            {
                BigInteger inner = current;
                for (int colz = 0; colz<matrix.GetLength(1); colz++)
                {
                    matrix[(int)rowz, colz] = inner;
                    inner *= 2;
                }
                current *= 2;
            }

            //Through the matrix
            BigInteger finalResult = 0;
            BigInteger row = matrix.GetLength(0) - 1;
            BigInteger col = 0;
            for (BigInteger i = 0; i<movesAmount; i++)
            {
                if (col<colsOfThePawn[(int)i])
                {
                    for (BigInteger c = col; c <= colsOfThePawn[(int)i]; c++)
                    {
                        finalResult += matrix[(int)row, (int)c];
                        matrix[(int)row, (int)c] = 0;
                        col = c;
                    } 
                }
                else
                {
                    for (BigInteger c = col; c >= colsOfThePawn[(int)i]; c--)
                    {
                        finalResult += matrix[(int)row, (int)c];
                        matrix[(int)row, (int)c] = 0;
                        col = c;
                    }  
                }

                if (row<rowsOfThePawn[(int)i])
                {
                    for (BigInteger r = row; r <= rowsOfThePawn[(int)i]; r++)
                    {
                        finalResult += matrix[(int)r, (int)col];
                        matrix[(int)r, (int)col] = 0;
                        row = r;
                    }
                }
                else
                {
                    for (BigInteger r = row; r >= rowsOfThePawn[(int)i]; r--)
                    {
                        finalResult += matrix[(int)r, (int)col];
                        matrix[(int)r, (int)col] = 0;
                        row = r;
                    }
                }
                
            }
            //Printing
            Console.WriteLine(finalResult);
        }
    }
}