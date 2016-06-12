    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Calculation_Problem
{
    static void Main()
    {
        List<string> input = Console.ReadLine().Split(' ').ToList();
        List<char> x = new List<char>();
        int a = 0;
        int sumTotal = 0;

        foreach (var word in input)
        {
            x.AddRange(word);
            for (int i = 0; i < word.Length; i++)
            {
                a = (word[i] - 97);

                int cecex = 0;
                while (cecex<(word.Length-i-1))
                {
                    a *= 23;
                    cecex++;
                }
                sumTotal += a;
            }
        }
        int end = sumTotal;
        string result = "";
        while (sumTotal>0)
        {
            int ostatak = sumTotal % 23;
            sumTotal /= 23;
            char concat = (char)(ostatak + 'a');
            result += concat;
        }
        string reverse = "";
        for (int i = result.Length-1; i >= 0; i--)
        {
            reverse += result[i];
        }
        Console.Write(reverse);
        Console.Write(" = {0}", end);
        Console.WriteLine();
    }

}