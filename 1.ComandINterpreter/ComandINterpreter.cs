using System;
using System.Collections.Generic;
using System.Linq;
    class ComandINterpreter
    {
        static void Main()
        {
        List<string> array =
           Console.ReadLine()
          .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
          .ToList();
        List<int> nov = new List<int>();

        string comand = Console.ReadLine();
        while (comand!="end")
        {
            try
            {
                DoComand(comand.Split(), array);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input parameters.");
            }

            comand = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", array));

    }

    private static void DoComand(string[] comand, List<string> array)
    {
        string action = comand[0];
        switch (action)
        {
            case "reverse":
                ExecuteReverseCommand(comand, array);
                break;
            case "sort":
                ExecuteSortCommand(comand, array);
                break;
            case "rollLeft":
                ExecuteRollLeftCommand(comand, array);
                break;
            case "rollRight":
                ExecuteRollRightCommand(comand, array);
                break;
        }

    }

    private static void ExecuteRollRightCommand(string[] comand, List<string> array)
    {
        int moveRight = int.Parse(comand[1]) % array.Count;
        string[] elefementsRight = array.Skip(array.Count - moveRight).Take(moveRight).ToArray();
        array.InsertRange(0, elefementsRight);
        array.RemoveRange(array.Count - moveRight, moveRight);
    }
    private static void ExecuteRollLeftCommand(string[] comand, List<string> array)
    {
        int moveLEft = int.Parse(comand[1]) % array.Count;
        string[] elementsLeft = array
                                .Take(moveLEft).ToArray();
        array.AddRange(elementsLeft);
        array.RemoveRange(0, moveLEft);
    }
    private static void ExecuteSortCommand(string[] comand, List<string> array)
    {
        int startIndex = int.Parse(comand[2]);
        if (startIndex == array.Count)
            throw new ArgumentException();
        int endIndex = int.Parse(comand[4]);
        array.Sort(startIndex,endIndex,StringComparer.InvariantCulture); //Sorting in this way a,A,b,B,c,C,d,D
    }
    private static void ExecuteReverseCommand(string[] comand, List<string> array)
    {
        int startIndex = int.Parse(comand[2]);
        if (startIndex==array.Count)
            throw new ArgumentException();
        int endIndex = int.Parse(comand[4]);
        array.Reverse(startIndex, endIndex);
    }
}   