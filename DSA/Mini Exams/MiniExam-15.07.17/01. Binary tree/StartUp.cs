using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Binary_tree
{
    public class StartUp
    {
        public static int p;
        public static bool isPretty = false;
        public static List<int> isPrettyResults = new List<int>();

        public class Node
        {
            public Node(double value)
            {
                this.Value = value;
            }

            public double Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }


        }

        public class Tree
        {
            public void Traverse(Node node, long searchedNumber)
            {
                if (node.Value == searchedNumber)
                {
                    isPretty = true;
                    return;
                }
                if (node == null || node.Value > searchedNumber)
                {
                    return;
                }

                node.Left = new Node(node.Value * p);
                node.Right = new Node((node.Value * p) + 1);

                this.Traverse(node.Left, searchedNumber);
                this.Traverse(node.Right, searchedNumber);
            }
        }

        static void Main()
        {
            p = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Node root = new Node(1);

            Tree tree = new Tree();

            foreach (var number in numbers)
            {
                tree.Traverse(root, number);
                if (isPretty)
                {
                    isPrettyResults.Add(1);
                }
                else
                {
                    isPrettyResults.Add(0);
                }
                isPretty = false;
            }

            Console.WriteLine(string.Join(" ", isPrettyResults));
        }
    }
}
