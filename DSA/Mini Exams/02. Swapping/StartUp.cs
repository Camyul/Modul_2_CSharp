using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Swapping
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] separ = { " " };
            List<int> numbers = Console.ReadLine().Split(separ, StringSplitOptions.None).Select(int.Parse).ToList();
            //int devider = 3;

            //int n = 6;
            Queue<int> sequence = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                sequence.Enqueue(i);
            }

            //List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                sequence = Swap(sequence, numbers[i]);
            }

            Console.WriteLine(String.Join(" ", sequence));
        }

        private static Queue<int> Swap(Queue<int> sequence, int devider)
        {
            sequence.Enqueue(devider);
            do
            {
                int element = sequence.Dequeue();
                if (element == devider)
                {
                    return sequence;
                }

                sequence.Enqueue(element);

            } while (true);
        }
    }
}
