using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        List<string> alfabet = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        string input = Console.ReadLine();
        long decimalrepresantation = 0;
        for (int i = 0; i < input.Length; i += 3)
        {
            string digitin13 = input.Substring(i, 3);
            int decimalvalue = alfabet.IndexOf(digitin13);
            decimalrepresantation *= 13;
            decimalrepresantation += decimalvalue;
        }
        Console.WriteLine(decimalrepresantation);

        //    List<string> alfabet = Console.ReadLine().Split(' ').ToList();
        //    string input = Console.ReadLine();
        //    int decimalRepresantation = 0; // or whatever is needed 
        //    for (int i = 0; i < input.Length; i +=3)
        //    {
        //        string digitIn2 = input.Substring(i, 3);
        //        int decimalvalue = alfabet.IndexOf(digitIn2);
        //           decimalRepresantation *= 2;
        //           decimalRepresantation+= decimalvalue;
        //    }
        //    Console.WriteLine(decimalRepresantation);
        //}
    }
}