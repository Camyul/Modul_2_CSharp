﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Zig_Zag_Sequences
{
    class Program
    {
        static void Main()
        {
            string[] arr = { "1", "2", "3", "4" };
            GeneratePermutations(arr, 0);
        }

        private static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
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
