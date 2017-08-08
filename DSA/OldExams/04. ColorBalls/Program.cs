using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ColorBalls
{
    class Program
    {
        static int count = 0;
        static void Main()
        {
            string sequence = Console.ReadLine();

            var colors = new Dictionary<char, int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (!colors.ContainsKey(sequence[i]))
                {
                    colors.Add(sequence[i], 1);
                }
                else
                {
                    colors[sequence[i]]++;
                }
            }

            GeneratePermWithRepeat(sequence.ToCharArray(), 0, sequence.Length);

            Console.WriteLine(count);
        }

        private static void GeneratePermWithRepeat(char[] arr, int start, int n)
        {
            Print(arr);
            count++;

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        GeneratePermWithRepeat(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
