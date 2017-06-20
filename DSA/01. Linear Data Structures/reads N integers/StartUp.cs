using System;
using System.Collections.Generic;

namespace reads_N_integers
{
    public class StartUp
    {
        static void Main()
        {
            int count = 3;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
