using System;
using System.Collections.Generic;
using System.Linq;
    class Program
    {
    private static ISet<string> validResources = new HashSet<string>()
            {
                "stone", "gold", "wood", "food"
            };
    private static bool[] cellsVisited;
    private static string[] resourceField;

    static void Main()
    {
         resourceField = Console.ReadLine().Split();
        int N = int.Parse(Console.ReadLine());
        int bestQty = 0;
        for (int i = 0; i < N; i++)
        {
            cellsVisited = new bool[resourceField.Length];
            string[] path = Console.ReadLine().Split();
            int start = int.Parse(path[0]);
            int step =  int.Parse(path[1]);
            int CurrentQty = tryGetResources(start);
            int currentIndex = (start + step) % resourceField.Length;
            while (!cellsVisited[currentIndex])
            {
                CurrentQty += tryGetResources(currentIndex);
                currentIndex = (currentIndex + step) % resourceField.Length;
            }
            if (CurrentQty > bestQty)
            {
                bestQty = CurrentQty;
            }

        }
        Console.WriteLine(bestQty);

    }

    private static int tryGetResources(int index)
    {
        string[] ResourcesTokens = resourceField[index].Split('_');
        string resource = ResourcesTokens[0];
        if(validResources.Contains(resource))
        {
            cellsVisited[index] = true;
            return ResourcesTokens.Length > 1 ? int.Parse(ResourcesTokens[1]) : 1;
        }
        return 0;
    }
}