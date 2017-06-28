using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StringsSubset
{
    internal static class StartUp
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            int[] numbers = new int[k];
            Console.Write("Set: ");
            string[] separator = { " " };
            string[] set = Console.ReadLine().Split(separator, StringSplitOptions.None);
            string[] arr = new string[k];
            bool[] used = new bool[n];

            GenerateVariationsNoRepetitions(k, 0, set, arr, used);
        }

        private static void GenerateVariationsNoRepetitions(int k, int index, string[] set, string[] arr, bool[] used)
        {
            if (index >= k)
            {
                Print(arr);
            }
            else
            {
                for (int i = index; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = set[i];
                        GenerateVariationsNoRepetitions(k, index + 1, set, arr, used);
                        used[i] = false;
                    }
                }
            }

        }
        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
