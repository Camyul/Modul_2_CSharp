using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfSequence
{
    class Program
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            List<int> results = new List<int>();
            List<int> finalResults = new List<int>();
            for (int i = 0; i < t; i++)
            {
                int[] nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int n = nk[0];
                int k = nk[1];

                int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int[] comb = new int[k];

                GenerateCombinationsNoRepeat(0, 0, k, n, sequence, comb, results);

                int finalResult = 0;
                foreach (var result in results)
                {
                    finalResult += result;
                }

                finalResults.Add(finalResult);

            }
                Console.WriteLine(string.Join("\n", finalResults));
        }

        private static void GenerateCombinationsNoRepeat(int index, int start, int k, int n, int[] arr, int[] comb, List<int> results)
        {
            if (index >= k)
            {
                results.Add(Sum(comb, arr));
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    comb[index] = i;
                    GenerateCombinationsNoRepeat(index + 1, i + 1, k, n, arr, comb, results);
                }
            }
        }

        private static int Sum(int[] combination, int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < combination.Length; i++)
            {
                sum += arr[combination[i]];
            }

            return sum;
            //Console.Write("( " + string.Join(", ", combination) + ") -->  ( ");
            //for (int i = 0; i < combination.Length; i++)
            //{
            //    Console.Write(arr[combination[i]] + " ");
            //}
            //Console.WriteLine(")");
        }
    }
}


/*
2
4 2
1 2 3 4
5 3
1 –5 7 10 –3
 
 */
