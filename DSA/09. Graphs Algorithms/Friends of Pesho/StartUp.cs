using System;
using System.Collections.Generic;
using System.Linq;

namespace Friends_of_Pesho
{
    class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int pointCount = numbers[0];
            int edgeCount = numbers[1];
            int hospitalCount = numbers[2];

            int[] hospitals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var priority = new SortedSet<Edge>();
            var edges = new List<Edge>();
            var minimalPathNodes = new List<Edge>();

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                edges.Add(new Edge(edge[0], edge[1], edge[2]));
            }

            foreach (var hospital in hospitals)
            {
                var used = new bool[pointCount + 1];
                minimalPathNodes.Clear();
                priority.Clear();
                for (int i = 0; i < edges.Count; i++)
                {
                    if (edges[i].StartNode == hospital)
                    {
                        priority.Add(edges[i]);
                        used[edges[i].StartNode] = true;
                        var path = FindMinimumSpanningTree(used, priority, minimalPathNodes, edges);
                        Console.WriteLine(path);
                    }
                }
            }
        }

        private static int FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> minimalPathNodes, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true; // we visit this node
                    minimalPathNodes.Add(edge);
                    AddEdges(edge, edges, minimalPathNodes, priority, used);
                }
            }
            return CalculateMinimumPath(minimalPathNodes);
        }

        private static int CalculateMinimumPath(List<Edge> minimalPathNodes)
        {
           return minimalPathNodes.Select(x => x.Weight).Sum();
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> minimalPathNodes, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!minimalPathNodes.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode] )
                    {
                        priority.Add(edge);
                    }
                }
            }
        }
    }
}
/*
3 2 1
1
1 2 1
3 2 2

5 8 2
1 2
1 2 5
4 1 2
1 3 1
3 4 4
4 5 1
2 4 3
5 2 1
2 3 20

*/
