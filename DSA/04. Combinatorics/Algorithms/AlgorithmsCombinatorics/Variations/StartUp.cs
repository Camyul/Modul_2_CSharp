using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variations
{
    class StartUp
    {
        static int numbersOfPositions = 3;
        static int variationsOfCurrentPosition = 8;
        static int[] arr = new int[numbersOfPositions];

        static void Main()
        {
            
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= numbersOfPositions)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i < variationsOfCurrentPosition; i++)
                {
                    arr[index] = i + 1;
                    GenerateVariations(index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
