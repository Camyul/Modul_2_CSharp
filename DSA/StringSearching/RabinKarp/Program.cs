using System;

namespace RabinKarp
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
            string text = "peshogoshoepesho";

            Console.WriteLine(text);
            // Single Rolling Hash
            var patternHash = new SingleRollingHash(29, 1000000007, pattern);
            var windowHash = new SingleRollingHash(29, 1000000007, text, pattern.Length);

            if (patternHash.Equals(windowHash))
            {
                PrintMatch(0, pattern);
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                windowHash.Roll(text[i + pattern.Length], text[i]);

                if (patternHash.Equals(windowHash))
                {
                    PrintMatch(i + 1, pattern);
                }
            }

            // Double Hashing
            var doublepatternHash = new Hash(pattern);
            var doublewindowHash = new Hash(text, pattern.Length);

            if (doublepatternHash.Equals(doublewindowHash))
            {
                PrintMatch(0, pattern);
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                doublewindowHash.Roll(text[i + pattern.Length], text[i]);

                if (doublepatternHash.Equals(doublewindowHash))
                {
                    PrintMatch(i + 1, pattern);
                }
            }
        }
    }
}
