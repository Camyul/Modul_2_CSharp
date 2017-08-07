using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWothoutRepeat
{
    class StartUp
    {
        const int n = 5;
        const int k = 3;
        static string[] objects = new string[n] { "apple", "banana", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[k];

        static void Main()
        {
            GenerateCombinationsNoRepeat(0, 0);
        }

        private static void GenerateCombinationsNoRepeat(int index, int start)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepeat(index + 1, i + 1);
                }
            }
        }

        private static void Print()
        {
            Console.Write("( " + string.Join(", ", arr) + ") -->  ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}
