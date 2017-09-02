using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Guards
{
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

    

    class Program
    {
        static HashSet<Node> guards = new HashSet<Node>();

        static void Main()
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            int[] rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int row = rc[0];
            int col = rc[1];

            //bool[,] guards = new bool[row, col];
            
            int numberSecurity = int.Parse(Console.ReadLine());

            var nodes = new Node[row, col];

            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var newNode = new Node(count);
                    count++;
                    nodes[i, j] = newNode;
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    List<Connection> edges = new List<Connection>();

                    if (i + 1 < row)
                    {
                        var newEdge = new Connection(nodes[i + 1, j], 1);
                        edges.Add(newEdge);
                    }
                    if (j + 1 < col)
                    {
                        var newEdge2 = new Connection(nodes[i, j + 1], 1);

                        edges.Add(newEdge2);
                    }

                    graph.Add(nodes[i, j], edges);
                }
                
            }

            for (int i = 0; i < numberSecurity; i++)
            {
                string[] position = Console.ReadLine().Split(' ').ToArray();
                int r = int.Parse(position[0]);
                int c = int.Parse(position[1]);
                string watch = position[2];

                guards.Add(nodes[r, c]);
                if (watch == "L")
                {
                    if (c - 2 >= 0)
                    {
                        graph[nodes[r, c - 2]][1].Distance += 2;
                    }
                    if (r - 1 >= 0 && c - 1 >= 0)
                    {
                        graph[nodes[r - 1, c - 1]][0].Distance += 2;
                    }
                    
                }
                else if (watch == "R")
                {
                    if (r - 1 >= 0 && c + 1 < col)
                    {
                        graph[nodes[r - 1, c + 1]][1].Distance += 2;
                    }
                    
                }
                else if (watch == "U")
                {
                    if (r - 1 >= 0 && c - 1 >= 0)
                    {
                        graph[nodes[r - 1, c - 1]][1].Distance += 2;
                    }
                    if (r - 2 >= 0)
                    {
                        graph[nodes[r - 2, c]][0].Distance += 2;
                    }
                }
                else if (watch == "D")
                {
                    if (r + 1 < row && c - 1 >= 0)
                    {
                        graph[nodes[r + 1, c - 1]][1].Distance += 2;
                    }
                }
            }

            DijkstraAlgorithm(graph, nodes[0, 0]);
            Console.WriteLine(nodes[row - 1, col - 1].DijkstraDistance);
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
                    if (!guards.Contains(neighbor.Node))
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
