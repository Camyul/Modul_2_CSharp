using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Swapping_v2
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, n).ToList();

            var swapNumbers = Console.ReadLine()
                         .Split()
                         .Select(int.Parse)
                         .ToArray();

            foreach (var num in swapNumbers)
            {
                int index = numbers.IndexOf(num);

            }

        }
    }
}
