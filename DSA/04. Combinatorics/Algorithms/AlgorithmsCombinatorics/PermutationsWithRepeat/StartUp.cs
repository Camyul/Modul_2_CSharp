using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithRepeat
{
    class StartUp
    {
        static void Main()
        {
            int[] arr = new int[]{ 3, 5, 1, 5, 5 };
            Array.Sort(arr);
            GeneratePermWithRepeat(arr, 0, arr.Length);
        }

        private static void GeneratePermWithRepeat(int[] arr,int start, int n)
        {
            Print(arr);

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
