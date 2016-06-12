using System;
using System.Collections.Generic;
using System.Linq;
  public  class ChampionsLegue
    {
    private static readonly IDictionary<string, int> winStatistics =
     new Dictionary<string, int>();
    private static readonly IDictionary<string, ISet<string>> oponentStatistics =
        new Dictionary<string, ISet<string>>();
    static void Main()
    {
        string line = "";
        while ((line=Console.ReadLine()) != "stop")
        {
            string[] input = line.Split('|').Select(s => s.Trim()).ToArray();
            string firstTeam = input[0];
            string secondTeam = input[1];
            string winningTeam = FindWinner(firstTeam, secondTeam, input[2], input[3]);
            addTeamToWinStatistics(firstTeam, firstTeam == winningTeam);
            addTeamToWinStatistics(secondTeam, secondTeam == winningTeam);
            addOponent(firstTeam, secondTeam);
            addOponent(secondTeam, firstTeam);
        }
        foreach (var pair in winStatistics.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
        {
            Console.WriteLine(pair.Key);
            Console.WriteLine("- Wins: " + pair.Value);
            Console.WriteLine("- Opponents: " + string.Join(", ", oponentStatistics[pair.Key]));
        }
    }

    private static void addOponent(string team, string oponent)
    {
        if(!oponentStatistics.ContainsKey(team))
        {
            oponentStatistics[team] = new SortedSet<string>();  
        }
        oponentStatistics[team].Add(oponent);
    }
    private static void addTeamToWinStatistics(string team, bool isWinner)
    {
       if(!winStatistics.ContainsKey(team))
        {
            winStatistics[team] = 0;
        }
       if(isWinner)
        {
            winStatistics[team]++;
        }
    }
    private static string FindWinner(string firstTeam, string secondTeam, string firstScore, string secondScore)
    {
        int[] firstMatchGoals = GetGoals(firstScore);
        int[] secondMatchGoals = GetGoals(secondScore);
        int firstTeamGoal = firstMatchGoals[0] + secondMatchGoals[1];
        int secondTeamGoal = firstMatchGoals[1] + secondMatchGoals[0];
        if (firstMatchGoals==secondMatchGoals)
        {
            return firstMatchGoals[1] > secondMatchGoals[1] ? firstTeam : secondTeam;
        }
        return firstTeamGoal > secondTeamGoal ? firstTeam : secondTeam;
    }
    private static int[] GetGoals(string score)
    {
        return score.Split(':').Select(int.Parse).ToArray();
    }
}