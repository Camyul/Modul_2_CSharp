using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jedi_Meditation
{
    public static class SortingClass
    {
        public static IList<string> ConvertToString(this IList<int> listToConvert, char name)
        {
            var jediByRole = new List<string>();

            foreach (var jedi in listToConvert)
            {
                jediByRole.Add(name + jedi.ToString());
            }

            return jediByRole;
        }

        public static IList<string> GetByRole(this IList<string> listToSort, char name)
        {
            var jediByRole = new List<string>();

            foreach (var jedi in listToSort)
            {
                if (jedi[0] == name)
                {
                    jediByRole.Add(jedi.Substring(1));
                }
            }

            return jediByRole;
        }

        public static void RadixLeftToRight(this IList<int> listToSort, int countDigits, int numberBase)
        {
            int basePower = 1;
            for (int i = 0; i < numberBase; i++)
            {
                basePower *= numberBase;
            }

            listToSort.RadixLR(basePower, countDigits - 1, numberBase);
        }

        private static void RadixLR(this IList<int> listToSort, int basePower, int digit, int numberBase)
        {
            if (digit < 0)
            {
                return;
            }

            var buckets = new List<int>[numberBase];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (var num in listToSort)
            {
                int currentDigit = num / basePower % numberBase;
                buckets[currentDigit].Add(num);
            }

            foreach (var bucket in buckets)
            {
                bucket.RadixLR(basePower / numberBase, digit - 1, numberBase);
            }

            int index = 0;
            foreach (var bucket in buckets)
            {
                foreach (var num in bucket)
                {
                    listToSort[index] = num;
                    ++index;
                }
            }
        }
    }
}
