using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SuperSum
{
    class Program  // 20/100
    {
        static long result;
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = input[0];
            int n = input[1];

            result = 0;
            result = SuperSum(k - 1, n);
            Console.WriteLine(result);
        }

        static long SuperSum(int k, int n)
        {

            if (k == 0)
            {
                return Sum(n);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    result += SuperSum(k-1, i);
                }
                return result;
            }

            
        }

        private static long Sum(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
