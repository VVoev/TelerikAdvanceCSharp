using System;
using System.Collections.Generic;
using System.Linq;
    class Even_Difference_Sid
    {
        static void Main()
        {
        long result = 0;
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        for (long i = 1; i < input.Length; )
        {
            long sum = Math.Abs(input[i] - input[i - 1]);
            if(sum%2==0)
            {
                result += sum;
                i += 2;
            }
            else
                i ++;
        }
        Console.WriteLine(result);
        }
    }