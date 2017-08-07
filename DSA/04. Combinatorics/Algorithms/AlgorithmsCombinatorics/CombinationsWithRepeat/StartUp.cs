using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithRepeat
{
    class StartUp
    {
        const int numberAllElements = 5;
        const int elementToCombine = 3;
        static string[] objects = new string[numberAllElements] { "apple", "banana", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[elementToCombine];

        static void Main()
        {
            GenerateCombinationsWithRepeat(0, 0);
        }

        private static void GenerateCombinationsWithRepeat(int index, int start)
        {
            if (index >= elementToCombine)
            {
                Print();
            }
            else
            {
                for (int i = start; i < numberAllElements; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsWithRepeat(index + 1, i);
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
