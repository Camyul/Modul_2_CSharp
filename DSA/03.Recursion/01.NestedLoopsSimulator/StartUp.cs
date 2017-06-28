using System;

namespace _01.NestedLoopsSimulator
{
    internal static class StartUp
    {
        static void Main()
        {            
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            Recursion(0, numbers);
        }

        private static void Recursion(int index, int[] numbers)
        {
            if (index >= numbers.Length)
            {
                PrintNumbers(numbers);
                //return;
            }
            else
            {
                for (int i = 1; i <= numbers.Length; i++)
                {
                    numbers[index] = i;
                    Recursion(index + 1, numbers);
                }
            }
        }

        private static void PrintNumbers(int[] numbers)
        {
             Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
