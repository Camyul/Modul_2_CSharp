﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TopFiftySequenceMembers
{
    internal static class StartUp
    {
        static void Main()
        {
            Console.Write("Enter N: ");
            int number = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

                queue.Enqueue(number);
            for (int i = 0; i < 50; i++)
            {
                number = queue.Dequeue();
                Console.WriteLine(number);
                queue.Enqueue(number + 1);
                queue.Enqueue(2 * number + 1);
                queue.Enqueue(number + 2);

            }

        }
    }
}
