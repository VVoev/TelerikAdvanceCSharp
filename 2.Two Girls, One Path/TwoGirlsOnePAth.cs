using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class TwoGirlsOnePAth
{
    static void Main()
    {
        int Molly = 0;
        int Dolly = 0;
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < array.Length; )
        {
            Molly += array[i];
            i = array[i];
        }
        for (int i = array.Length-1; i >= 0; i--)
        {
            Dolly += array[i];
        }
    }
}