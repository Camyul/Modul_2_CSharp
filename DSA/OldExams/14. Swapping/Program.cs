using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Swapping
{
    public class ListNode : IEnumerable<int>
    {
        public ListNode(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public int Value { get; set; }
        public ListNode Left { get; set; }
        public ListNode Right { get; set; }

        public void LinkRight(ListNode node)
        {
            this.Right = node;
            node.Left = this;
        }
        public void Detach()
        {
            if (this.Left != null)
            {
                this.Left.Right = null;
                this.Left = null;
            }
            if (this.Right != null)
            {
                this.Right.Left = null;
                this.Right = null;
            }
        }

        public IEnumerator<int> GetEnumerator() // За да може да се принтира
        {
            var node = this;
            while (node != null)
            {
                yield return node.Value;
                node = node.Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = Enumerable.Range(0, n + 1)
                .Select(x => new ListNode(x))
                .ToArray();

            for (int i = 1; i < n; i++)
            {
                nodes[i].LinkRight(nodes[i + 1]);
            }

            var first = nodes[1];
            var last = nodes[n];

            Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList()
                .ForEach(num =>
                {
                    var newLast = nodes[num].Left;
                    var newFirst = nodes[num].Right;

                    nodes[num].Detach();
                    if (last != nodes[num])
                    {
                        last.LinkRight(nodes[num]);
                    }
                    else
                    {
                        newFirst = nodes[num];
                    }

                    if (first != nodes[num])
                    {
                        nodes[num].LinkRight(first);
                    }
                    else
                    {
                        newLast = nodes[num];
                    }

                    first = newFirst;
                    last = newLast;
                });

            Console.WriteLine(string.Join(" ", first));
        }
    }
}
