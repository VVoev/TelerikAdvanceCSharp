using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TRES4Number_Telerik
{
    static void Main()
    {
        int numeralsystem = 9;// it is equal to the number of words we have
        ulong n = ulong.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        List<string> alfabet = new List<string> { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
        do
        {
            int digitInNine = (int)(n % (ulong)numeralsystem);
            n /= (ulong)numeralsystem;
            sb.Insert(0, alfabet[digitInNine]); // we use insert if we want to add always in front 
        } while (n>0);
        Console.WriteLine(sb.ToString());
    }
}