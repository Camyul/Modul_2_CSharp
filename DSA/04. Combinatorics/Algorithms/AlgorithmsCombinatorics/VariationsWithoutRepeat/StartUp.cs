using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariationsWithoutRepeat
{
    class StartUp
    {
        static int numbersOfPositions = 3;
        static int variationsOfCurrentPosition = 5;
        static int[] arr = new int[numbersOfPositions];
        static bool[] used = new bool[variationsOfCurrentPosition];
        static void Main()
        {

            GenerateVariationsNoRepeat(0);
        }

        private static void GenerateVariationsNoRepeat(int index)
        {
            
            if (index >= numbersOfPositions)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i < variationsOfCurrentPosition; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i + 1;
                        GenerateVariationsNoRepeat(index + 1);
                        used[i] = false;
                    }
                    
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
