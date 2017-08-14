using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Zig_Zag_Sequences
{
    class Program
    {
        static int count;

        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = input[0];
            int k = input[1];

            if (k == 1)
            {
                Console.WriteLine(n);
                return;
            }
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i;
            }

            count = 0;
            int[] currentVariation = new int[k];
            bool[] used = new bool[n];
            GenerateVariationsNoRepetitions(0, currentVariation, used, numbers);

            Console.WriteLine(count);
           
        }

        static void GenerateVariationsNoRepetitions(int index, int[] currVariation, bool[] used, int[] numbers)
        {
            if (index >= currVariation.Length)
            {
                int tempCount = 0;
                for (int i = 0; i < currVariation.Length - 1; i++)
                {
                    if (currVariation[i] > currVariation[i + 1] && i % 2 == 0)
                    {
                        tempCount++;
                    }
                    else if (currVariation[i] < currVariation[i + 1] && i % 2 == 1)
                    {
                        tempCount++;
                    }
                }
                if (tempCount == currVariation.Length - 1)
                {
                    ++count;
                }
                
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currVariation[index] = i;
                        
                        GenerateVariationsNoRepetitions(index + 1, currVariation, used, numbers);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariations(int[] currVariation, int[] numbers)
        {
            Console.Write("(" + String.Join(", ", currVariation) + ") --> ( ");
            for (int i = 0; i < currVariation.Length; i++)
            {
                Console.Write(numbers[currVariation[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}
