using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearching
{
    class Program
    {
        static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(pattern);
        }
        static void Main(string[] args)
        {
            string pattern = "pesho";
            string text = "gosho e po malyk ot pesho,pesho";
            Console.WriteLine(text);
            for (int i = 0; i + pattern.Length - 1 < text.Length; i++)
            {
                bool match = true;
                
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != text[i + j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    // Console.WriteLine($"Found at {i}");
                    PrintMatch(i, pattern);
                }
            }
        }
    }
}
