using System;

namespace _03.CombinationsWithoutDuplicates
{
    internal static class StarUp
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            int[] numbers = new int[k];
            Recursion(n, 0, 0, numbers);
        }

        private static void Recursion(int n, int index, int start, int[] numbers)
        {
            if (index == numbers.Length)
            {
                PrintNumber(numbers);
                return;
            }

            for (int i = start; i <= numbers.Length; i++)
            {
                numbers[index] = i + 1;
                Recursion(n, index + 1, i + 1, numbers);
            }
        }

        private static void PrintNumber(int[] numbers)
        {
            Console.WriteLine($"({string.Join(" ", numbers)})");
        }
    }
}
