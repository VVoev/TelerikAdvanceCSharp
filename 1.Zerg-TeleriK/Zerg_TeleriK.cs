using System;
using System.Collections.Generic;
using System.Linq;
class Zerg_TeleriK
{
    static void Main()
    {
        List<string> alfabet = new List<string> { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
        string input = Console.ReadLine();
        long decimalRepresentation = 0;
        for (int i = 0; i < input.Length; i+=4)
        {
            string digitIn15 = input.Substring(i, 4);
            int decimalValue = alfabet.IndexOf(digitIn15);
            decimalRepresentation *= 15;
            decimalRepresentation += decimalValue;
        }
        Console.WriteLine(decimalRepresentation);
    }
}