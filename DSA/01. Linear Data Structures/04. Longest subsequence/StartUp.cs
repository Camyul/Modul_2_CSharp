using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_subsequence
{
    public class StartUp
    {
        static void Main()
        {
            IList<int> listOfInt = new List<int>() { 2, 3, 3, 1, 5, 5, 5, 2, 2, 1, 1, 1, 1, 5, 4, 4, 4 };

            IList<int> tempLonguestSequence = new List<int>();

            IList<int> longuestSequence = new List<int>();

            for (int i = 0; i < listOfInt.Count - 1; i++)
            {
                tempLonguestSequence.Add(listOfInt[i]);

                if (listOfInt[i] != listOfInt[i + 1])
                {
                    if (longuestSequence.Count < tempLonguestSequence.Count)
                    {
                        longuestSequence.Clear();
                        longuestSequence = tempLonguestSequence.ToList();
                    }

                    tempLonguestSequence.Clear();
                }
            }

            Console.WriteLine(string.Join(", ", longuestSequence));
        }
    }
}
