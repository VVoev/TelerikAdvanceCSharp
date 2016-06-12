using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
    {
        static void Main()
        {
        List<string> words = Console.ReadLine().Split(' ').ToList();
        List<string> reverseWords = new List<string>();
        foreach (var word in words)
        {
            string nov = "";
            for (int i = word.Length-1; i >= 0; i--)              //reversing all words 
            {
                nov += word[i];
            }
            reverseWords.Add(nov);
        }
        StringBuilder result = new StringBuilder();
        int maxlenght = -1000;
        maxlenght = words.Max(x => x.Length);
        for (int i = 0; i < maxlenght; i++)
        {
            foreach (var word in reverseWords)
            {
                if (word.Length > i)
                {
                    result.Append(word[i]);
                }
            }
        }
        //Changing positions
        for (int i = 0; i < result.Length; i++)
        {
            char currentSymbol = result[i];// taking the the symbol
            int transition = char.ToLower(currentSymbol) - 'a' + 1; //see how much you need to move
            int nextPosition = (i + transition) % result.Length; // we use % to avoid geting out of range
            result.Remove(i, 1);                                 //removing the current symbol
            result.Insert(nextPosition, currentSymbol);          //ading it on it new place
        }
        Console.WriteLine(result);

    }
    }