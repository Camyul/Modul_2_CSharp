using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Friends
{
    class Program
    {                                       // 10/100
        public class Node : IComparable
        {
            public Node(int id)
            {
                this.Id = id;
            }

            public int Id { get; private set; }

            public double DijkstraDistance { get; set; }

            public int CompareTo(object obj)
            {
                if (!(obj is Node))
                {
                    return -1;
                }

                return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
            }
        }

        public class Connection
        {
            public Connection(Node node, double distance)
            {
                this.Node = node;
                this.Distance = distance;
            }

            public Node Node { get; set; }

            public double Distance { get; set; }
        }

        static void Main()
        {
            List<Node> nodes = new List<Node>();
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberCities = nm[0];
            int numberEdges = nm[1];

            for (int i = 1; i <= numberCities; i++)
            {
                nodes.Add(new Node(i));
            }

            int[] startEnd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startNode = startEnd[0];
            int endNode = startEnd[1];

            int[] middles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstMiddle = middles[0];
            int secondMiddle = middles[1];
            int pathBetweenMiddle = 0;

            for (int i = 0; i < numberEdges; i++)
            {
                int[] links = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int firstNode = links[0];
                int secondNode = links[1];

                if ((firstMiddle == firstNode && secondMiddle == secondNode) || (firstMiddle == secondNode && secondMiddle == firstNode))
                {
                    pathBetweenMiddle = links[2];
                }

                Connection firstConnection = new Connection(nodes[secondNode - 1], links[2]);
                Connection secondConnection = new Connection(nodes[firstNode - 1], links[2]);

                

                if (graph.ContainsKey(nodes[firstNode - 1]))
                {
                    graph[nodes[firstNode - 1]].Add(firstConnection);
                }
                else
                {
                    graph.Add(nodes[firstNode - 1], new List<Connection> { firstConnection });
                }

                if (graph.ContainsKey(nodes[secondNode - 1]))
                {
                    graph[nodes[secondNode - 1]].Add(secondConnection);
                }
                else
                {
                    graph.Add(nodes[secondNode - 1], new List<Connection> { secondConnection });
                }
            }

            Node source = nodes[startNode - 1];
            DijkstraAlgorithm(graph, source);
            double pathToFirstMiddle = nodes[firstMiddle - 1].DijkstraDistance;
            double pathToSecondMiddle = nodes[secondMiddle - 1].DijkstraDistance;

            double result1 = 0;

            if (pathToFirstMiddle <= pathToSecondMiddle)
            {
                source = nodes[firstMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToStartNode = nodes[startNode - 1].DijkstraDistance;

                source = nodes[secondMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToEndNode = nodes[endNode - 1].DijkstraDistance;

                result1 = pathToStartNode + pathBetweenMiddle + pathToEndNode;
                //Console.WriteLine(pathToStartNode);
                //Console.WriteLine(pathBetweenMiddle);
                //Console.WriteLine(pathToEndNode);
            }
            else
            {
                source = nodes[secondMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToStartNode = nodes[startNode - 1].DijkstraDistance;

                source = nodes[firstMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToEndNode = nodes[endNode - 1].DijkstraDistance;

                result1 = pathToStartNode + pathBetweenMiddle + pathToEndNode;
                //Console.WriteLine(pathToStartNode);
                //Console.WriteLine(pathBetweenMiddle);
                //Console.WriteLine(pathToEndNode);
            }

            source = nodes[endNode - 1];
            DijkstraAlgorithm(graph, source);
            pathToFirstMiddle = nodes[firstMiddle - 1].DijkstraDistance;
            pathToSecondMiddle = nodes[secondMiddle - 1].DijkstraDistance;

            double result2 = 0;

            if (pathToFirstMiddle <= pathToSecondMiddle)
            {
                source = nodes[secondMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToStartNode = nodes[startNode - 1].DijkstraDistance;

                source = nodes[firstMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToEndNode = nodes[endNode - 1].DijkstraDistance;

                result2 = pathToStartNode + pathBetweenMiddle + pathToEndNode;
                //Console.WriteLine(pathToStartNode);
                //Console.WriteLine(pathBetweenMiddle);
                //Console.WriteLine(pathToEndNode);
            }
            else
            {
                source = nodes[firstMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToStartNode = nodes[startNode - 1].DijkstraDistance;

                source = nodes[secondMiddle - 1];
                DijkstraAlgorithm(graph, source);

                double pathToEndNode = nodes[endNode - 1].DijkstraDistance;

                result2 = pathToStartNode + pathBetweenMiddle + pathToEndNode;
                //Console.WriteLine(pathToStartNode);
                //Console.WriteLine(pathBetweenMiddle);
                //Console.WriteLine(pathToEndNode);
            }

            double result = Math.Min(result1, result2);
            Console.WriteLine(result);
            
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Node.DijkstraDistance)
                    {
                        neighbor.Node.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }
        }

        public class PriorityQueue<T> where T : IComparable
        {
            private T[] heap;
            private int index;

            public PriorityQueue()
            {
                this.heap = new T[16];
                this.index = 1;
            }

            public int Count
            {
                get
                {
                    return this.index - 1;
                }
            }

            public void Enqueue(T element)
            {
                if (this.index >= this.heap.Length)
                {
                    this.IncreaseArray();
                }

                this.heap[this.index] = element;

                int childIndex = this.index;
                int parentIndex = childIndex / 2;
                this.index++;

                while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
                {
                    T swapValue = this.heap[parentIndex];
                    this.heap[parentIndex] = this.heap[childIndex];
                    this.heap[childIndex] = swapValue;

                    childIndex = parentIndex;
                    parentIndex = childIndex / 2;
                }
            }

            public T Dequeue()
            {
                T result = this.heap[1];

                this.heap[1] = this.heap[this.Count];
                this.index--;

                int rootIndex = 1;

                while (true)
                {
                    int leftChildIndex = rootIndex * 2;
                    int rightChildIndex = (rootIndex * 2) + 1;

                    if (leftChildIndex > this.index)
                    {
                        break;
                    }

                    int minChild;
                    if (rightChildIndex > this.index)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                        {
                            minChild = leftChildIndex;
                        }
                        else
                        {
                            minChild = rightChildIndex;
                        }
                    }

                    if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                    {
                        T swapValue = this.heap[rootIndex];
                        this.heap[rootIndex] = this.heap[minChild];
                        this.heap[minChild] = swapValue;

                        rootIndex = minChild;
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }

            public T Peek()
            {
                return this.heap[1];
            }

            private void IncreaseArray()
            {
                var copiedHeap = new T[this.heap.Length * 2];

                for (int i = 0; i < this.heap.Length; i++)
                {
                    copiedHeap[i] = this.heap[i];
                }

                this.heap = copiedHeap;
            }
        }
    }
}
