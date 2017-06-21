using System;
using System.Collections.Generic;

namespace Sequence_of_integers
{
    public class StartUp
    {
        static void Main()
        {
            List<int> sequence = new List<int>();

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

            sequence.Sort();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
