using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            List<string> digits = new List<string>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                digits.Add(i.ToString());
            }
            for (char i = 'a'; i <= 'i'; i++)
            {
                for (char y = 'A'; y <= 'Z'; y++)
                {
                    digits.Add(i.ToString() + y.ToString());
                }
            }
            string result = "";
            if (number == 0)
                Console.WriteLine("A");
            while (number != 0)
            {
                result = digits[(int)(number % 256)] + result;
                number = number / 256;
            }
            Console.WriteLine(result);
        }
    }
}
