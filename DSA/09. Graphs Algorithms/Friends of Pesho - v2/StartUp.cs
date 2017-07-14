using System;
using System.Linq;
using System.Collections.Generic;

namespace Friends_of_Pesho___v2
{
    public class StartUp
    {
        static void Main()
        {
            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int pointNumber = inputNumbers[0];
            int streetNumber = inputNumbers[1];
            int hospitalNumber = inputNumbers[2];

            int[] allHospitals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Dictionary<Node, List<Edge>> graph = new Dictionary<Node, List<Edge>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < streetNumber; i++)
            {
                int[] currentStreet = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int firstNode = currentStreet[0];
                int secondNode = currentStreet[1];
                int distance = currentStreet[2];

                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }


                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                Node firstNodeObject = allNodes[firstNode];
                Node secondNodeObject = allNodes[secondNode];

                if (!graph.ContainsKey(firstNodeObject))
                {
                    graph.Add(firstNodeObject, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNodeObject))
                {
                    graph.Add(secondNodeObject, new List<Edge>());
                }

                graph[firstNodeObject].Add(new Edge(secondNodeObject, distance));
                graph[secondNodeObject].Add(new Edge(firstNodeObject, distance));


            }
            for (int j = 0; j < allHospitals.Length; j++)
            {
                int currentHospital = allHospitals[j];

                allNodes[currentHospital].IsHospital = true;
            }

            long result = long.MaxValue;

            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = allHospitals[i];

                DijkstraAlgorithm(graph, allNodes[currentHospital]);

                long temporarySum = 0;

                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        temporarySum += node.Value.DijkstraDistance;
                    }
                }

                if (temporarySum < result)
                {
                    result = temporarySum;
                }
            }

            Console.WriteLine(result);
        }

        static void DijkstraAlgorithm(Dictionary<Node, List<Edge>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + edge.Distance;

                    if (potDistance < edge.ToNode.DijkstraDistance)
                    {
                        edge.ToNode.DijkstraDistance = potDistance;
                        queue.Enqueue(edge.ToNode);
                    }
                }
            }
        }
    }

    public class Edge
    {
        public Edge(Node toNode, long distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public long Distance { get; set; }
    }

    public class Node : IComparable
    {
        public Node(int id)
        {
            ID = id;
            this.IsHospital = false;
        }

        public int ID { get; set; }

        public long DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
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
