using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindArrayMajorant
{
    internal static class StartUp
    {
        static void Main()
        {
            int[] sequence = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            int? majorant = GetMajorant(sequence);

            if (majorant == null)
            {
                Console.WriteLine("Array haven't majorant!");
            }
            else
            {
                Console.WriteLine($"Array majorant is: {majorant}");
            }
        }

        private static int? GetMajorant(int[] sequence)
        {
            int minCount = (sequence.Length / 2) +1;

            int? result = null;

            sequence
                .ToList()
                .ForEach(x =>
                {
                    int count = sequence.ToList().FindAll(num => num == x).Count();
                    if (count >= minCount)
                    {
                        result = x;
                    }
                });

            return result;
        }
    }
}
