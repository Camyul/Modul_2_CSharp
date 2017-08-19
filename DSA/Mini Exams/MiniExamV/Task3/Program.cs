using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long sum = 0;
            long minOdd = long.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                    sum = sum + numbers[i];
                
                if (numbers[i] % 2 != 0)
                {
                    if (minOdd > Math.Abs(numbers[i]))
                    {
                        minOdd = Math.Abs(numbers[i]);
                    }
                }
            }
        
            if (sum % 2 == 0)
            {
                sum = sum - minOdd;
            }

            Console.WriteLine(sum);
        }
    }
}
