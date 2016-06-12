using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoroTheRabbit
{
    static void Main()

    {
        int[] terrain = ReadInput();

        int maxLength = 0;
        int step = 1;

        for (int i = 0; i < terrain.Length; i++)
        {
            bool[] workArray = new bool[terrain.Length];
            int currentmax = 1;
            int index = i;
            while (!workArray[index] && terrain[index] < terrain[(index + step) % terrain.Length])
            {
                currentmax++;
                workArray[index] = true;
                index = (index + step) % terrain.Length;
            }
            if (currentmax > maxLength)
            {
                maxLength = currentmax;
            }
            if (i == terrain.Length - 1)
            {
                i = -1;
                step++;
            }
            if (step > terrain.Length)
            {
                break;
            }
        }
        Console.WriteLine(maxLength);
    }
    static int[] ReadInput()
    {
        return Console.ReadLine()
                               .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
    }
}