using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bike
{
    class StartUp
    {
        public class DijkstraWithoutQueue
        {
            private static int rows;
            private static int cols;
            private static readonly double[] Distance = new double[500];
            private static readonly double?[] Previous = new double?[500];
            private static readonly HashSet<int> SetOfNodes = new HashSet<int>();

            public static void Dijkstra(double[,] graph, int source)
            {
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    Distance[i] = int.MaxValue;
                    Previous[i] = null;
                    SetOfNodes.Add(i);
                }

                Distance[source] = 0;

                while (SetOfNodes.Count != 0)
                {
                    int minNode = int.MaxValue;

                    foreach (var node in SetOfNodes)
                    {
                        if (minNode > Distance[node])
                        {
                            minNode = node;
                        }
                    }

                    SetOfNodes.Remove(minNode);

                    if (minNode == int.MaxValue)
                    {
                        break;
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        if (graph[minNode, i] > 0)
                        {
                            double potentialDistance = Distance[minNode] + graph[minNode, i];
                            if (potentialDistance < Distance[i])
                            {
                                Distance[i] = potentialDistance;
                                Previous[i] = minNode;
                            }
                        }
                    }
                }
            }

            public static void Main()
            {
                rows = int.Parse(Console.ReadLine());

                cols = int.Parse(Console.ReadLine());

                double[,] graph = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    double[] row = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                    for (int j = 0; j < cols; j++)
                    {
                        graph[i, j] = row[j];
                    }
                }

                int source = 1;

                Dijkstra(graph, source - 1);
                Console.WriteLine(string.Join(",", Distance));

                //for (int i = 0; i < Distance.Length; i++)
                //{
                //    Console.Write("Distance from 1 to {0}: ", i + 1);
                //    if (Distance[i] == int.MaxValue)
                //    {
                //        Console.WriteLine("No path.");
                //    }
                //    else
                //    {
                //        Console.Write("Path: ");

                //        int? indexer = i;
                //        while (indexer != 0)
                //        {
                //            Console.Write(indexer + 1 + " ");
                //            indexer = (int)Previous[indexer.Value];
                //        }

                //        Console.Write("1 ");

                //        Console.WriteLine("Distance: " + Distance[i]);
                //    }
                //}
            }
        }
    }
}
/*
4
4
1 8 9 6
1 4,3 2,7 -3
1 -64 3 3
1 1 1 1
 */
