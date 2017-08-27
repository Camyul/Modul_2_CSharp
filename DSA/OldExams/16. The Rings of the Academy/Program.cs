using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _16.The_Rings_of_the_Academy
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var rings = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                rings[element]++;
            }

            var factorials = new BigInteger[rings.Max() + 1];
            factorials[0] = 1;
            for (int i = 1; i < factorials.Length; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }

            BigInteger total = 1;
            for (int i = 1; i < rings.Length; i++)
            {
                total *= factorials[rings[i]];
            }

            Console.WriteLine(total);
        }
    }
}
