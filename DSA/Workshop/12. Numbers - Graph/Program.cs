using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Numbers___Graph
{
    class Program
    {
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

        static void Main()
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int row = size[0];
            int col = size[1];

            Node[,] nodes = new Node[row, col];
            for (int i = 0; i < row; i++)
            {
                 int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                 for (int j = 0; j < line.Length; j++)
                 {
                    nodes[i, j] = new Node(line[j]);
                 }
                
            }
            var graph = new Dictionary<Node, List<Connection>>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i + 1 < row)
                    {
                        int distance = Math.Abs(nodes[i + 1, j].Id - nodes[i, j].Id);
                        Connection newConnection = new Connection(nodes[i + 1, j], distance);
                        if (!graph.ContainsKey(nodes[i, j]))
                        {
                            graph.Add(nodes[i, j], new List<Connection>());
                        }
                        graph[nodes[i, j]].Add(newConnection);
                    }
                    if (i - 1 >= 0)
                    {
                        int distance = Math.Abs(nodes[i - 1, j].Id - nodes[i, j].Id);
                        Connection newConnection = new Connection(nodes[i - 1, j], distance);
                        if (!graph.ContainsKey(nodes[i, j]))
                        {
                            graph.Add(nodes[i, j], new List<Connection>());
                        }
                        graph[nodes[i, j]].Add(newConnection);
                    }
                    if (j + 1 < col)
                    {
                        int distance = Math.Abs(nodes[i, j + 1].Id - nodes[i, j].Id);
                        Connection newConnection = new Connection(nodes[i, j + 1], distance);
                        if (!graph.ContainsKey(nodes[i, j]))
                        {
                            graph.Add(nodes[i, j], new List<Connection>());
                        }
                        graph[nodes[i, j]].Add(newConnection);
                    }
                    if (j - 1 >= 0)
                    {
                        int distance = Math.Abs(nodes[i, j - 1].Id - nodes[i, j].Id);
                        Connection newConnection = new Connection(nodes[i, j - 1], distance);
                        if (!graph.ContainsKey(nodes[i, j]))
                        {
                            graph.Add(nodes[i, j], new List<Connection>());
                        }
                        graph[nodes[i, j]].Add(newConnection);
                    }
                }
            }

            DijkstraAlgorithm(graph, nodes[0, 0]);
            PrintMatrix(nodes);
            Console.WriteLine(nodes[row - 1, col - 1].DijkstraDistance);
        }

        public static void PrintMatrix(Node[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col].DijkstraDistance);
                }
                Console.WriteLine();
            }
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
    }
}
