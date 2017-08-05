using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    class StartUp2
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> result = new List<int>();

            result.Add(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                if (result.Count % i > 0)
                {
                    result.Add(numbers[i]);
                    continue;
                }
                result.Add(numbers[i]);
                
                int k = 0;
                for (int j = 0; k < numbers.Length; j++, k++)
                {
                    if (j >= result.Count)
                    {
                        j = 0;
                    }
                    if (result[j] != numbers[k])
                    {
                        break;
                    }
                    if (k == numbers.Length - 1)
                    {
                       Console.WriteLine(string.Join(" ", result));
                       return;
                    }
                }
            }

            
        }
    }
}
