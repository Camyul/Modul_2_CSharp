using System;
using System.Linq;

namespace _07.How_many_times_each_of_them_occurs
{
    internal static class StartUp
    {
        static void Main()
        {
            int[] sequence = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            sequence
                .Distinct()
                .OrderBy(n => n)
                .ToList()
                .ForEach(x =>
                {
                    int count = sequence.ToList().FindAll(num => num == x).Count();
                    Console.WriteLine($"{x} - {count} times");
                });
        }
    }
}
