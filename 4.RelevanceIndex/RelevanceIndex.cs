using System;
using System.Collections.Generic;
using System.Linq;
class RelevanceIndex
{
    static void Main()
    {
        var dictionary = new Dictionary<List<string>, int>();
        string text = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        var input = new List<string>();
        for (int i = 0; i < n; i++)
        {
            input.Add(Console.ReadLine().Replace(",", ""));
        }
        List<string> occurence = new List<string>();
        foreach (var item in input)
        {
            int count = 0;
            occurence = item.Split(new char[] { ' ', ',', '.', '(', ')', ';', '-', '!', '?' }).ToList();
            for (int i = 0; i < occurence.Count; i++)
            {
                if(occurence[i]==text)
                {
                    count++;
                    string x = occurence[i].ToUpper();
                    occurence.Remove(occurence[i]);
                    occurence.Insert(i , x.ToUpper());
                }
            }

            dictionary.Add(occurence, count);
        }

        foreach (var item in dictionary.OrderByDescending(i => i.Value))
        {
            Console.WriteLine(string.Join(" ", item.Key));
        }
    }
}