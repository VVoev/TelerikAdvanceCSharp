using System;
using System.Collections.Generic;
using System.Linq;
    class TheyAreGreen_Telerik
    {
    private static bool NextPermutation(int[] numList)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        var largestIndex = -1;
        for (var i = numList.Length - 2; i >= 0; i--)
        {
            if (numList[i] < numList[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        var largestIndex2 = -1;
        for (var i = numList.Length - 1; i >= 0; i--)
        {
            if (numList[largestIndex] < numList[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        var tmp = numList[largestIndex];
        numList[largestIndex] = numList[largestIndex2];
        numList[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
        {
            tmp = numList[i];
            numList[i] = numList[j];
            numList[j] = tmp;
        }

        return true;
    }
    static void Main()
        {
        int n = int.Parse(Console.ReadLine());
        int[] letter = new int[n];
        for (int i = 0; i < n; i++)
        {
            letter[i] =(int)char.Parse(Console.ReadLine());
        }
        Array.Sort(letter);
        int counter = 0;
        if(IsValid(letter))
        {
            counter++;
        }

        while(NextPermutation(letter))
        {
            if(IsValid(letter))
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
        }
    static bool IsValid(int[]letters)
    {
        int previuous = letters[0];
        for (int i = 1; i < letters.Length; i++)
        {
            if(letters[i]==previuous)
            {
                return false;
            }
            previuous = letters[i];
        }
        return true;
    }
    }