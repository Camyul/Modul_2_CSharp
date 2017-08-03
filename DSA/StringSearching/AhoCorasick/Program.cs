using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhoCorasick
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new String[]
            {
                "a",
                "ab",
                "bab",
                "bc",
                "bca",
                "c",
                "caa"
            };
           
            var root = new Trie();
            foreach (var str in strings)
            {
                root.AddString(str);
            }

            root.Precompute();
            // trie.Dfs();

            var text = "asdbbasbcbascbabcbabcsabc";
            Console.WriteLine(text);
            root.AhoCorasick(text);
        }
    }
}
