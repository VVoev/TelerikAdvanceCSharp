using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine());
        }
        //Reorder
        for (int i = 0; i < n; i++)
        {
            var word = words[i];
            var newIndex = word.Length % (n + 1);
            words.Insert(newIndex, word);
            if(newIndex<i)
            {
                words.RemoveAt(i + 1);
            }
            else
            {
                words.RemoveAt(i);
            }
        }
        //Print
        int maxlenght = 0;
        foreach (var word in words)
        {
            maxlenght = Math.Max(maxlenght, word.Length);
        }
        // LINQ query                          maxlenght = words.Max(x => x.Length);
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < maxlenght; i++)
        {
            foreach (var word in words)
            {
                if (word.Length > i)
                {
                    result.Append(word[i]);
                }
            }
        }
        Console.WriteLine(result.ToString());
    }
}