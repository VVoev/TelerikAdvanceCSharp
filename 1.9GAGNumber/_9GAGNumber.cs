using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class _9GAGNumber
    {
    public static ulong result = 0;
    public static Dictionary<string, ulong> alfabet = new Dictionary<string, ulong> {
    { "-!", 0 },
    { "**", 1 },
    { "!!!", 2 },
    { "&&", 3 },
    { "&-", 4 },
    { "!-", 5 },
    { "*!!!", 6 },
    { "&*!", 7},
    { "!!**!-", 8 } };
    static void Main()
    {
        string input = Console.ReadLine();
        var sb = new StringBuilder();
        bool numberFound = false;
        while(!numberFound)
        {
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i].ToString());
                if (alfabet.ContainsKey(sb.ToString()))
                {
                    ulong number = alfabet[sb.ToString()];
                    result = result * 9 + number;
                    sb.Clear();
                }
            }
            numberFound = true;
        }
        Console.WriteLine(result);
    }
    }