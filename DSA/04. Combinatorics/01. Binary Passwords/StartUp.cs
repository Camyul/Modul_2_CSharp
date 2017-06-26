using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Binary_Passwords
{
    internal static class StartUp
    {
        static void Main()
        {
            string pass = Console.ReadLine();
            List<int> groups = new List<int>();
            int count = 1;

            for (int i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == '*')
                {
                    if (pass[i] == '*' && pass[i + 1] == '*')
                    {
                        count++;
                    }
                    else
                    {
                        groups.Add(count);
                        count = 1;
                    }
                }
            }
            if (count > 1)
            {
                groups.Add(count);
            }
            double result = 1;
            foreach (var pow in groups)
            {
                result *= Math.Pow(2, pow);
            }
            Console.WriteLine(result);
        }
    }
}
