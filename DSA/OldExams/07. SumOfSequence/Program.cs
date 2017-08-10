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
            int result = 0;
            var results = new List<int>();
            for (int i = 0; i < t; i++)
            {
                int[] nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int n = nk[0];
                int k = nk[1];

                int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int[] comb = new int[k];

                result = 0;
                GenerateCombinationsNoRepeat(0, 0, k, n,ref sequence, comb, ref result);

                results.Add(result);

            }
            Console.WriteLine(string.Join("\n", results));
        }

        private static void GenerateCombinationsNoRepeat(int index, int start, int k, int n,ref int[] arr, int[] comb, ref int results)
        {
            if (index >= k)
            {
                results += Sum(comb,ref arr);
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    comb[index] = i;
                    GenerateCombinationsNoRepeat(index + 1, i + 1, k, n,ref arr, comb, ref results);
                }
            }
        }

        private static int Sum(int[] combination,ref int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < combination.Length; i++)
            {
                sum += arr[combination[i]];
            }

            return sum;
        }
    }
}


/*
2
4 2
1 2 3 4
5 3
1 –5 7 10 –3

1
4 2
-1 2 3 4
 
 */
