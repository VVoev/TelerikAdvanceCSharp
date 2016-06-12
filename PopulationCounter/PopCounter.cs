using System;
using System.Collections.Generic;
using System.Linq;
class PopCounter
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> populationData = new Dictionary<string, Dictionary<string, long>>();
        string input = Console.ReadLine();
        while (input!="Report")
        {
            string []data = input.Split('|').ToArray();
            string country = data[1];
            string city = data[0];
            long population =long.Parse(data[2]);

            if (!populationData.ContainsKey(country))
            {
                populationData.Add(country, new Dictionary<string, long>());
            }
            populationData[country].Add(city, population);
            input = Console.ReadLine();
        }
        var SortedPopulationData=populationData.OrderByDescending(x=>x.Value.Sum(y=>y.Value));
        foreach (var data in SortedPopulationData)
        {
            long totalPopulation = data.Value.Sum(x => x.Value);
            Console.WriteLine(
                "{0} (total population: {1})",
                data.Key,
                totalPopulation);

            var orderedCityData = data.Value
                .OrderByDescending(x => x.Value);

            foreach (var cityInfo in orderedCityData)
            {
                Console.WriteLine("=>{0}: {1}", cityInfo.Key, cityInfo.Value);
            }
        }


    }
}