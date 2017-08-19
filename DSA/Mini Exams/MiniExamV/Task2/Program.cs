using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task2
{
    class Program
    {
        public class Bridge : IComparable
        {
            public Bridge(int start, int end, int maxWeight)
            {
                this.Start = start;
                this.End = end;
                this.MaxWeight = maxWeight;
            }

            public int Start { get; set; }
            public int End { get; set; }
            public int MaxWeight { get; set; }
            

            public int CompareTo(object obj)
            {
                Bridge other = obj as Bridge;

                return this.MaxWeight - other.MaxWeight;

            }
        }

        static void Main()
        {
            // OrderedBag<Bridge> briges = new OrderedBag<Bridge>();
            int count = 0;
            List<Bridge> briges = new List<Bridge>();

            var pointAndBridges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int points = pointAndBridges[0];
            int numberBridges = pointAndBridges[1];

            for (int i = 0; i < numberBridges; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                briges.Add(new Bridge(line[0], line[1], line[2]));
            }

            int stiveWeight = int.Parse(Console.ReadLine());

            foreach (var brige in briges)
            {
                if (brige.MaxWeight >= stiveWeight)
                {
                    count++;
                }
            }

            briges.Sort();

            int[] color = new int[numberBridges];
            for (int i = 0; i < numberBridges; ++i)
            {
                color[i] = i;
            }

            for (int i = 0; i < briges.Count; i++)
            {
                Bridge e = briges[i];

                if (color[e.Start] != color[e.End])
                {
                    if (e.MaxWeight >= stiveWeight)
                    {
                        count++;
                    }
                    int oldColor = color[e.End];
                    for (int j = 0; j < numberBridges; ++j)
                    {
                        if (color[j] == oldColor)
                        {
                            color[j] = color[e.Start];
                        }
                    }
                }
            }

            Console.WriteLine(count - 1);
        }
    }
}
