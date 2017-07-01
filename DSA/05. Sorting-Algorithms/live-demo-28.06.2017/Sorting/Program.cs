using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 1000;
            var array = new int[SIZE];

            var rnd = new Random();
            for (int i = 0; i < SIZE; ++i)
            {
                array[i] = rnd.Next() % 1000;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            array.RadixRightToLeft(2, 65536);
            //array.MergeSortIterative();
            stopwatch.Stop();
            Console.WriteLine(String.Join(" ", array));
            Console.WriteLine(stopwatch.Elapsed);



            //Console.WriteLine(string.Join(" ", array));
            for (int i = 1; i < array.Length; ++i)
            {
                if(array[i - 1] > array[i])
                {
                    Console.WriteLine("Error");
                    break;
                }
            }
        }
    }
}
