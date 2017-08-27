using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Bike
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
            Node other = obj as Node;
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double[][] heights = new double[rows][];
            Node[][] nodes = new Node[rows][];

            for (int i = 0; i < rows; i++)
            {
                heights[i] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                //for (int j = 0; j < heights[i].Length; j++)
                //{
                //    nodes[i][j].DijkstraDistance = heights[i][j];
                //}
            }
            int count = 0;
            for (int row = 0; row < heights.Length; row++)
            {
                nodes[row] = new Node[heights[row].Length];
                for (int col = 0; col < heights[row].Length; col++)
                {
                    nodes[row][col] = new Node(count);
                    count++;
                }
            }

            var graph = new Dictionary<Node, List<Connection>>();

            for (int row = 0; row < nodes.Length; row++)
            {
                for (int col = 0; col < nodes[row].Length; col++)
                {
                    graph[nodes[row][col]] = GetNaeighbours(heights, nodes, row, col);
                }
            }

              DijkstraAlgorithm(graph, nodes[0][0]);
            Console.WriteLine("{0:f2}", nodes[rows - 1][cols - 1].DijkstraDistance + Math.Abs(heights[0][0] + Math.Abs(heights[rows - 1][cols - 1])));
        }

        public static List<Connection> GetNaeighbours(double[][] heights, Node[][] nodes, int row, int col)
        {
            var neighbours = new List<Connection>();

            if (row > 0)
            {
                neighbours.Add(new Connection(nodes[row - 1][col], Math.Abs(heights[row - 1][col] - heights[row][col])));

                if (row % 2 == 0)
                {
                    if (col > 0)
                    {
                        neighbours.Add(new Connection(nodes[row - 1][col - 1], Math.Abs(heights[row - 1][col - 1] - heights[row][col])));
                    }
                }
                else
                {
                    if (col < nodes[row].Length - 1)
                    {
                        neighbours.Add(new Connection(nodes[row - 1][col + 1], Math.Abs(heights[row - 1][col + 1] - heights[row][col])));
                    }
                }
            }
            if (row < nodes.Length - 1)
            {
                neighbours.Add(new Connection(nodes[row + 1][col], Math.Abs(heights[row + 1][col] - heights[row][col])));

                if (row % 2 == 0)
                {
                    if (col > 0)
                    {
                        neighbours.Add(new Connection(nodes[row + 1][col - 1], Math.Abs(heights[row + 1][col - 1] - heights[row][col])));
                    }
                }
                else
                {
                    if (col < nodes[row].Length - 1)
                    {
                        neighbours.Add(new Connection(nodes[row + 1][col + 1], Math.Abs(heights[row + 1][col + 1] - heights[row][col])));
                    }
                }
            }
            if (col > 0)
            {
                neighbours.Add(new Connection(nodes[row][col - 1], Math.Abs(heights[row][col - 1] - heights[row][col])));
            }
            if (col < nodes[row].Length - 1)
            {
                neighbours.Add(new Connection(nodes[row][col + 1], Math.Abs(heights[row][col + 1] - heights[row][col])));
            }

            return neighbours;
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
