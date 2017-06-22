using System;

namespace _12.ResizableStack
{
    internal static class StartUp
    {
        static void Main()
        {
            ResizableStack<int> stack = new ResizableStack<int>();
            int interactions = 17;

            for (int i = 0; i < interactions; i++)
            {
                stack.Push(i);
                Console.WriteLine($"Added '{i}' to stack! --- Count: {stack.Count} --- Capacity: {stack.Capacity}");
            }

            Console.WriteLine(new string('-', 64));

            for (int i = 0; i < interactions; i++)
            {
                int poped = stack.Pop();
                Console.WriteLine($"Poped element ot stack with value: {poped} --- Stack count: {stack.Count}");
            }
        }
    }
}
