using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            for (int i = 1; i < str.Length; i++)
            {
                if (str.Length % i > 0)
                {
                    continue;
                }
                string pattern = str.Substring(0, i);
                bool isResult = true;
                for (int j = i; j < str.Length; j+=i)
                {
                    if (pattern != str.Substring(j, i))
                    {
                        isResult = false;
                        break;
                    }
                }
                if (isResult)
                {
                    Console.WriteLine(pattern);
                    break;
                }
            }
        }
    }
}
