using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Catcoding
{
    static void Main()
    {
        var input = Console.ReadLine().Split().ToArray();
        List<string> output = new List<string>();
        long number = -10000; long value = 0;
        foreach (var word in input)
        {
           value=ConvertTonumber(word,number);
            var builder = new StringBuilder();
            while (value>0)
            {
                char bukva =(char)((value % 26) + 'a');
                builder.Insert(0, bukva);
                value /= 26;
            }
            Console.Write(builder.ToString()+" ");
        }
        Console.WriteLine();
    }

     static long ConvertTonumber(string word,long number)
    {
        long total = 0;
        for (int i = 0; i < word.Length; i++)
        {
            long res = 0; 
            number = word[i] - 'a';
            while (res<word.Length-i-1)
            {
                number *= 21;
                res++;
            }
            total += number;
        }
        return total;
    }
}