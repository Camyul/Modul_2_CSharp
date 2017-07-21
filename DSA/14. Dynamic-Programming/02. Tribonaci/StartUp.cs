using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02.Tribonaci
{
    class StartUp
    {
        static int firstElement;
        static int secondElement;
        static int thirdElement;
        static int number;

        static BigInteger[] tribonacciMemo = new BigInteger[100000];

        static BigInteger Tribonacci(int n)
        {
            if (n == 3)
            {
                return thirdElement;
            }

            if (n == 2)
            {
                return secondElement;
            }

            if (n == 1)
            {
                return firstElement;
            }
            if (tribonacciMemo[n] == 0)
            {
                tribonacciMemo[n] = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
            }

            return tribonacciMemo[n];
        }
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            firstElement = input[0];
            secondElement = input[1];
            thirdElement = input[2];
            number = (int)input[3];

            Console.WriteLine(Tribonacci(number));
        }
    }
}
