using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.tree_of_N_nodes
{
    class StartUp
    {
        static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Cildren)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "Tree has no  root.");
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                string[] edgeParts = Console.ReadLine().Split(' ');
                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Cildren.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            //1. Find root
            Console.WriteLine("The root of the tree is: {0}", FindRoot(nodes).Value);

            //2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.Write("Leafs: ");

            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            //3. Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.Write("Middle Nodes: ");

            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }
            Console.WriteLine();

            //4. Find Longest Path from the root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Longest path from the root is: {0}", longestPath);

            //5. DFS Recursive
            Console.Write("DFS with recursion: ");
            DFSRecursive(FindRoot(nodes));
            Console.WriteLine(FindRoot(nodes).Value);

            //6. DFS with stack
            Console.Write("DFS withstack: ");
            DFS(FindRoot(nodes));
            Console.WriteLine();

            //6. BFS with queue
            Console.Write("BFS: ");
            BFS(FindRoot(nodes));
            Console.WriteLine();
        }

        private static void BFS(Node<int> node)
        {
            Queue<Node<int>> stack = new Queue<Node<int>>();
            stack.Enqueue(node);
            while (stack.Count > 0)
            {
                Node<int> currentNode = stack.Dequeue();
                Console.Write(" {0}", currentNode.Value);
                foreach (var child in currentNode.Cildren)
                {
                    stack.Enqueue(child);
                }
            }
        }

        private static void DFS(Node<int> node)
        {
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                Node<int> currentNode = stack.Pop();
                Console.Write(" {0}", currentNode.Value);
                foreach (var child in currentNode.Cildren)
                {
                    stack.Push(child);
                }
            }
        }

        private static void DFSRecursive(Node<int> node)
        {
            //Console.Write("{0} ", node.Value);

            foreach (var child in node.Cildren)
            {
                DFSRecursive(child);
                Console.Write("{0} ", child.Value);
            }
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Cildren.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Cildren)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }
            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Cildren.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Cildren.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }
    }
}
/*
7
2 4
3 2
5 0
3 5
5 6
5 1
*/