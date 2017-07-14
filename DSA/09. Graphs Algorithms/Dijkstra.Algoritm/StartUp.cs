using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Algoritm
{                               //Не работи коректно
    class StartUp
    {
        static string inputWeightedGraph = @"0 3 7
0 4 3
0 5 5
1 2 10
1 3 2
1 4 1
2 4 100
2 5 17
3 4 1
4 5 3";

        static void Main()
        {
            Dijkstra();
        }

        private static void Dijkstra()
        {
            int vertex = 0;
            List<WeightedNode>[] vertices = ReadInput(inputWeightedGraph);

            var visited = new HashSet<int>();
            var queue = new SortedSet<WeightedNode>();
            int[] distance = Enumerable.Repeat(int.MaxValue, vertices.Length).ToArray();

            distance[vertex] = 0;
            queue.Add(new WeightedNode(vertex, 0));

            var path = new int[vertices.Length];
            path[vertex] = -1;

            while (queue.Count > 0)
            {
                var current = queue.Min;
                queue.Remove(current);
                visited.Add(current.Vertex);
                // calculate distance

                vertices[current.Vertex].ForEach(neighbour =>
                {
                    var currentDistance = distance[neighbour.Vertex];
                    var newDistance = distance[current.Vertex] = neighbour.Weight;
                    if (currentDistance > newDistance)
                    {
                        distance[neighbour.Vertex] = newDistance;
                        queue.Add(new WeightedNode(neighbour.Vertex, newDistance));
                        path[neighbour.Vertex] = current.Vertex;
                    }
                });

                // remove top visited from queue
                while (queue.Count > 0 && visited.Contains(queue.Min.Vertex))
                {
                    queue.Remove(queue.Min);
                }

            }
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine("{0} -> {1} through {2}",i, distance[i], path[i]);

            }
        }

        private static List<WeightedNode>[] ReadInput(string input)
        {
            int n = 6;
            var vertices = new List<WeightedNode>[n];
            input.Split('\n').ToList()
                    .ForEach(edge =>
                    {
                        var parts = edge.Split(' ');
                        var v1 = int.Parse(parts[0]);
                        var v2 = int.Parse(parts[1]);
                        var w = int.Parse(parts[2]);
                        if (vertices[v1] == null)
                        {
                            vertices[v1] = new List<WeightedNode>();
                        }
                        if (vertices[v2] == null)
                        {
                            vertices[v2] = new List<WeightedNode>();
                        }
                        vertices[v1].Add(new WeightedNode(v2, w));
                        vertices[v2].Add(new WeightedNode(v1, w));
                    });
            return vertices;
        }
    }
}
