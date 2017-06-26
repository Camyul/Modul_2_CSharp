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

            int count = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] == '*')
                {
                        count++;
                    
                }
            }
            double result = Math.Pow(2, count);

            Console.WriteLine(result);
        }
    }
}
