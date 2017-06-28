using System;

namespace _05.NKSubsets
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

            GenerateVariations(k, 0, set, arr);

        }

        private static void GenerateVariations<T>(int k, int index, T[] set, T[] arr)
        {
            if (index >= k)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    arr[index] = set[i];
                    GenerateVariations(k, index + 1, set, arr);
                }
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
