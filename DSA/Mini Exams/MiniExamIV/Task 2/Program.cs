using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main()
        {
            int[] pattern = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //string pattern = string.Join("", numbers);
            //string pattern = Console.ReadLine();
            //string text = pattern + pattern;

            int[] fl = new int[pattern.Length + 1];
            fl[0] = -1;
            fl[1] = 0;

            for (int i = 1; i < pattern.Length; i++)
            {
                int j = fl[i];
                while (j >= 0 && pattern[i] != pattern[j])
                {
                    j = fl[j];
                }

                fl[i + 1] = j + 1;
            }

            //int matched = 0;
            //for (int i = 1; i < text.Length; i++)
            //{
            //    while (matched >= 0 && text[i] != pattern[matched])
            //    {
            //        matched = fl[matched];
            //    }

            //    matched++;

            //    if (matched == pattern.Length)
            //    {
            //        var result = pattern.Substring(0, i - pattern.Length + 1);
            //        Console.WriteLine(string.Join(" ", result.ToCharArray()));
            //        break;
            //    }
            }
        }
    }
}
