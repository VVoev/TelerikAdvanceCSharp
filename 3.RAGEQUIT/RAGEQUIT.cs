namespace RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RageQuit
    {
        public static void Main()
        {
            Regex pairMatcher = new Regex(@"(\D+)(\d+)"); //   (\D+)macha posledovatelnosta dokato stigne chislo
                                                         //    (\d+)machva edin ili pove4e broq cifri dokato stigne bukva
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            Match pair = pairMatcher.Match(input);
            do
            {
                string str = pair.Groups[1].Value.ToUpper();
                int counter = int.Parse(pair.Groups[2].Value);
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(str);
                }
                pair = pair.NextMatch();
            } while (pair.Success);

            int uniqueSymbols = sb.ToString().Distinct().Count();

            Console.WriteLine("Unique symbols used: {0}", uniqueSymbols);
            Console.WriteLine(sb);


        }
    }
}