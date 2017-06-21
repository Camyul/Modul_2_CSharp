using System;
using System.Collections.Generic;

namespace Removes_occur_odd_number_of_times
{
    public class StartUp
    {
        static void Main()
        {
            IList<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            IList<int> listOfRemoved = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int item = sequence[i];

                if (IsOdd(item))
                {
                    int count = 1;

                    for (int j = 0; j < sequence.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (item == sequence[j])
                        {
                            count++;
                        }
                    }

                    if (count > 1)
                    {
                        listOfRemoved.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", listOfRemoved));
        }

        private static bool IsOdd(int item)
        {
            if (item % 2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
