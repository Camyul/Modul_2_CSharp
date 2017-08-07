using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stringland_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            // string pattern = "efg";
            int matcherCount = 0;
            int dif = int.Parse(Console.ReadLine());
            //string text = "abcd efg higk";
            bool haveMatch = false;
            string text = Console.ReadLine();
            List<int> matches = new List<int>();

            int[] failLink = PreComputeKMP(pattern);
            
            //Console.WriteLine(string.Join(" ", failLink));
            // Console.WriteLine(text);

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (j >= 0 && pattern[j] != text[i])
                {
                    j = failLink[j];
                }

                ++j;
                if (j == pattern.Length)
                {
                    matcherCount++;
                    int index = i - j + 1;
                    matches.Add(index);
                    // PrintStr(dif, index, text, pattern.Length);
                    haveMatch = true;
                    
                    j = failLink[j];
                }
            }

            if (!haveMatch)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Console.WriteLine(matcherCount);
                foreach (var match in matches)
                {
                    PrintStr(dif, match, text, pattern.Length);
                }
            }
        }

      

        private static void PrintStr(int dif, int index, string text, int count)
        {
            if (dif == 0)
            {
                Console.WriteLine("index: {0} - string: {1}", index, text.Substring(index, count));
            }
            else if (dif == 1)
            {
                Console.WriteLine("index: {0} - string: {1}", index - 1, text.Substring(index - 1, count));
                Console.WriteLine("index: {0} - string: {1}", index, text.Substring(index, count));
            }
            else if (dif == 2)
            {
                Console.WriteLine("index: {0} - string: {1}", index - 1, text.Substring(index - 1, count));
                Console.WriteLine("index: {0} - string: {1}", index, text.Substring(index, count));
                // Проверка да не излиза от целия текст
                Console.WriteLine("index: {0} - string: {1}", index + 1, text.Substring(index + 1, count));
            }
        }

        static int[] PreComputeKMP(string str)
        {
            int[] failLink = new int[str.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;
            for (int i = 1; i < str.Length; i++)
            {
                int j = failLink[i];
                while (j >= 0 && str[i] != str[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            return failLink;
        }
    }
}
