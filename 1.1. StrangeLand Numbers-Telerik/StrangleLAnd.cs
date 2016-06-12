using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class StrangleLAnd
{
    public static Dictionary<string, long> alfabet = new Dictionary<string, long> {
    { "f", 0 },
    { "bIN", 1 },
    { "oBJEC", 2 },
    { "mNTRAVL", 3 },
    { "lPVKNQ", 4 },
    { "pNWE", 5 },
    { "hT", 6 } };
    static void Main()
    {
        //input
        long result = 0;
        long number = 0;
        int counter = 0;
        var sb = new StringBuilder();
        string text = Console.ReadLine();
        for (int i = text.Length-1; i >=0; i--)
        {
            sb.Insert(0, text[i]);
            if(alfabet.ContainsKey(sb.ToString()))//checking if dictionary contain string
            {
                number = alfabet[sb.ToString()];//number =position string in Dictionary
                if (counter > 0)
                {
                    int x = counter;
                    while (x > 0)
                    {
                        number *= 7;
                        x--;
                    }
                }
                counter++;
                result += number;
                sb.Clear();
            }
        }
        Console.WriteLine(result);
    }
}