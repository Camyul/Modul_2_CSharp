using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Extracts_from_a_given_sequence_odd_number
{
    public class StartUp
    {
        static void Main()
        {
            string[] array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            // SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

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

            Console.Write("{ ");
            foreach (var num in dictionary)
            {
                if (num.Value % 2 > 0)
                {
                    Console.Write("{0}, ", num.Key);
                }
            }
            Console.Write(" }");
        }
    }
}
