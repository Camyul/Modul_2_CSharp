using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Counts_in_a_given_array
{
    public class StartUp
    {
        static void Main()
        {
            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            // Dictionary<double, int> dictionary = new Dictionary<double, int>();
            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    dictionary[array[i]] += 1;
                }
                else
                {
                    dictionary.Add(array[i], 1);
                }
            }

            foreach (var num in dictionary)
            {
                Console.WriteLine("{0} -> {1}", num.Key, num.Value);
            }
        }
    }
}
