using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Greedy
{
    public static int max = int.MinValue;
    public static int bestCoins = 0;
    static void Main()
    {
        int [] moneyPath = Console.ReadLine().Trim().Split(',').Select(int.Parse).ToArray();
        int[] copy = new int[moneyPath.Length];

        for (int i = 0; i < moneyPath.Length; i++)
        {
            copy[i] = moneyPath[i];
        }
        int numberofPatterns = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberofPatterns; i++)
        {
            for (int j = 0; j < copy.Length; j++)
            {
                moneyPath[j] = copy[j];
            }
            int[] path = Console.ReadLine().Trim().Split(',').Select(int.Parse).ToArray();
            int totalCoins = path[0];
            int step = path[0];
            int currentposition = 0;
            int x = 1;

            while (true)
            {
                currentposition += step;
                if (currentposition < 0 || currentposition > moneyPath.Length-1 || moneyPath[currentposition]==0)
                {
                    break;
                }
                moneyPath[0] = 0;
                totalCoins+=moneyPath[currentposition];
                moneyPath[currentposition] = 0;
                if(x>=path.Length)
                {
                    x = 0;
                }
                step = path[x];
                x++;
            }
            if (totalCoins > bestCoins)
                bestCoins = totalCoins;

            max = Math.Max(totalCoins, bestCoins);
        }
        Console.WriteLine(max);
    }
}