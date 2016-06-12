using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
class TwoGirlsOnePAth
{
    static void Main()
    {
        BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        string winner = "";
        int mollyIndex = 0;
        int dollyIndex = numbers.Length - 1;

        BigInteger mollyTotalFlowers = 0;
        BigInteger dollyTotalFlowers = 0;

        while (true)
        {
            if(numbers[mollyIndex]==0 || numbers[dollyIndex]==0)
            {
               if (numbers[mollyIndex]==0 && numbers[dollyIndex]==0)
                {
                    winner = "Draw";
                }
               else if(numbers[mollyIndex]==0)
                {
                    winner = "Dolly";
                }
               else
                {
                    winner = "Molly";
                }
                mollyTotalFlowers += numbers[mollyIndex];
                dollyTotalFlowers += numbers[dollyIndex];
                break;
            }

            BigInteger currentMolyFlowers = numbers[mollyIndex];
            BigInteger currentDolyFlowers = numbers[dollyIndex];

            numbers[mollyIndex] = 0;
            numbers[dollyIndex] = 0;

            mollyTotalFlowers += currentMolyFlowers;
            dollyTotalFlowers += currentDolyFlowers;

            mollyIndex = (int)((mollyIndex+currentMolyFlowers) % numbers.Length);
            dollyIndex = (int)((dollyIndex+currentDolyFlowers)% numbers.Length);
            if(dollyIndex<0)
            {
                dollyIndex += numbers.Length;
            }

        }
        Console.WriteLine(winner);
        Console.WriteLine("{0} {1}",mollyTotalFlowers,dollyTotalFlowers);
    }
}