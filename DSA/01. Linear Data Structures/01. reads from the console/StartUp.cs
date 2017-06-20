using System;
using System.Collections.Generic;

namespace Reads_from_the_console
{
    public class StartUp
    {
        static void Main()
        {
            IList<int> sequence = new List<int>();

            while (true)
            {
                int number;
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    sequence.Add(number);
                }
                else
                {

                    if (input == string.Empty)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter correct number!");
                    }
                }
            }

            int sum = 0;
            foreach (var num in sequence)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
