using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Combinations_with_duplicates
{
    class Program
    {
        static void Main()
        {
            int n = 4;
            int k = 2;

            int[] arr = new int[k];

            //GenerateCombinationWithDuplication(n, 0, 0, arr);
            GenerateCombinationWithOutDuplication(n, 0, 0, arr);
        }

        private static void GenerateCombinationWithOutDuplication(int n, int index, int start, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine($"({string.Join(" ", arr)})");
                return;
            }

            for (int i = start; i <= n + 1; i++)
            {
                arr[index] = i + 1;
                GenerateCombinationWithDuplication(n, index + 1, i + 1, arr);
            }
        }

        private static void GenerateCombinationWithDuplication(int n, int index, int start, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine($"({string.Join(" ", arr)})");
                return;
            }

            for (int i = start; i <= arr.Length; i++)
            {
                arr[index] = i + 1;
                GenerateCombinationWithDuplication(n, index + 1, i, arr);
            }
        }
    }
}
