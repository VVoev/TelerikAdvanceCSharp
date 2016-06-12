using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
    {
        static void Main()
        {
        int counter = 0;
        var separators = new char[] { '"', '=', ':', '<', '!', '>','/',' ' };
        var words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        while (words[0]!="stop")
        {
            if (words[0] == "inverse")
            {
                StringBuilder Sb = new StringBuilder();
                if (words.Count > 2)
                {
                    foreach (var item in words[2])
                    {
                        if (char.IsLower(item))
                            Sb.Append(char.ToUpper(item));
                        else
                            Sb.Append(char.ToLower(item));
                    }
                    counter++;
                    Console.WriteLine("{0}. {1}", counter, Sb);
                }
                else
                {
                    counter++;
                    Console.WriteLine("{0}. {1}", counter, Sb);
                }

            }
            else if (words[0] == "reverse" && words.Count>2)
            {
                string prazen = words[2];
                string nov = "";
                for (int i = prazen.Length-1; i>=0; i--)
                {
                    nov += prazen[i]; 
                }
                counter++;
                Console.WriteLine("{0}. {1}",counter,nov);
            }
            else if (words[0] == "repeat")
            {
                int zacikala = int.Parse(words[2]);
                if (zacikala > 0)
                {
                    for (int i = 0; i < zacikala; i++)
                    {
                        counter++;
                        Console.WriteLine("{0}. {1}", counter, words[4]);
                    }
                }
                else
                {
                    counter++;
                    Console.WriteLine("{0}. {1}", counter, words[4]);
                }
            }
            words= Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
    }