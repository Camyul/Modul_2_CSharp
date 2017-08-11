using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Penguin_airlines
{
    class Program
    {
        static Dictionary<int, Island> islands = new Dictionary<int, Island>();
        static bool haveFlight = false;

        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string flights = Console.ReadLine();
                var newIsland = new Island();
                if (flights != "None")
                {
                    int[] line = flights.Split(' ').Select(int.Parse).ToArray();

                    for (int j = 0; j < line.Length; j++)
                    {
                        var newFlight = new Flight(i, line[j]);
                        newIsland.Flights.Add(newFlight);
                    }
                }

                islands.Add(i, newIsland);
            }

            var querys = new List<Flight>();

            while (true)
            {
                string queryToString = Console.ReadLine();
                if (queryToString == "Have a break")
                {
                    break;
                }

                int[] query = queryToString.Split(' ').Select(int.Parse).ToArray();
                Flight newFlight = new Flight(query[0], query[1]);
                querys.Add(newFlight);
            }

            for (int i = 0; i < querys.Count; i++)
            {
                haveFlight = false;
                Flight currentFlight = querys[i];
                Island currentIsland = islands[currentFlight.startIsland];
                HashSet<Island> visited = new HashSet<Island>();

                foreach (var flight in currentIsland.Flights)
                {
                    if (flight.endIsland == currentFlight.endIsland)
                    {
                        Console.WriteLine("There is a direct flight.");
                        haveFlight = true;
                        break;
                    }
                }

                if (haveFlight)
                {
                    continue;
                }

                visited.Add(currentIsland);
                Dfs(currentIsland, currentFlight, visited);

                if (haveFlight)
                {
                    Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    continue;
                }
                else
                {
                    Console.WriteLine("No flights available.");
                }

            }
        }

        private static void Dfs(Island currentIsland, Flight currentFlight, HashSet<Island> visited)
        {
            //visited.Add(currentIsland);

            foreach (var flight in currentIsland.Flights)
            {
                if (flight.endIsland == currentFlight.endIsland)
                {
                    haveFlight = true;
                    return;
                }
                if (!visited.Contains(islands[flight.endIsland]))
                {
                    visited.Add(islands[flight.endIsland]);
                    Dfs(islands[flight.endIsland], currentFlight, visited);
                }
            }
        }
    }

    public class Flight
    {
        public Flight(int startIsland, int endIsland)
        {
            this.startIsland = startIsland;
            this.endIsland = endIsland;
        }

        public int startIsland { get; set; }
        public int endIsland { get; set; }
    }

    public class Island
    {
        public Island()
        {
            this.Flights = new List<Flight>();
        }

        public List<Flight> Flights { get; set; }
    }
}
/*
4
2 3
None
0
0
2 1
3 2
Have a break
*/
