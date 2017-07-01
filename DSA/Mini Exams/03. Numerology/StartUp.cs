using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Numerology
{
    class StartUp
    {

        static void Main()
        {
        //int n = int.Parse(Console.ReadLine());
        int n = 18790314;

            while (n > 10)
            {

                Stack<int> newNumber = new Stack<int>();
                int len = n.ToString().Length / 2;

                for (int i = 0; i < len; i++)
                {
                    n = GetAandB(n, newNumber);

                }

                List<int> meddium = new List<int>();

                len = newNumber.Count;
                for (int i = 0; i < len; i++)
                {
                    meddium.Add(newNumber.Pop());
                }

            Console.WriteLine(String.Join("", meddium));
                n = int.Parse(String.Join("", meddium));
            }

        }

        private static int GetAandB(int n, Stack<int> newNumber)
        {
            int ab = n % 100;
            n = n / 100;

            int b = ab % 10;
            int a = ab / 10;

            int num = GetNumeric(a, b);
            //newNumber.Push(num);
            Console.WriteLine(num);
            int result = int.Parse(n.ToString() + num);
            Console.WriteLine(result);

            return result;
        }

        private static int GetNumeric(int a, int b)
        {
            int result = 0;

            result = (a + b) * (a ^ b) % 10;

            return result;
        }
    }
}
