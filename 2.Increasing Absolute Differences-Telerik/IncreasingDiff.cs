using System;
using System.Collections.Generic;
using System.Linq;
class IncreasingDiff
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool increasing = true;
        for (int i = 0; i < n; i++)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            CheckingDifference(numbers,increasing);
        }
    }

     static List<int> CheckingDifference(List<int> numbers, bool increasing)
    {
        int seq = -1; 
        for (int i = 1; i < numbers.Count; i++)
        {
            int difference = Math.Abs(numbers[i] - numbers[i - 1]);
            if (difference >= seq)
            {
                seq = difference;
            }
            else
            {
                increasing = false;
            }
        }
        Console.WriteLine(increasing);
        return numbers;
    }
}