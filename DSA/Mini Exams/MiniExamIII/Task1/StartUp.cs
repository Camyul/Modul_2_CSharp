using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            char baseNum = (k - 1).ToString()[0];

            int maxNum = int.Parse(new string(baseNum, n));
            int minNum = int.Parse(new string(baseNum, n - 1));

            int result = 0;
            if (n == 2)
            {
                result = (maxNum - minNum);

            }
            else if (n == 3)
            {
                result = (maxNum - minNum - (k - 1));

            }

            else if (n == 4)
            {
                result = (maxNum - minNum - ((k - 1) * (2 * k - 1)));

            }
            else if (n == 5)
            {
                result = (maxNum - minNum - ((2 * (k - 1) + k) * k * (k - 1)));

            }
            else if (n == 6)
            {
                result = (maxNum - minNum - (k - 1) * ((41 * (k - 1) * k) + 1));

            }
            else if (n == 7)
            {
                result = (maxNum - minNum - ((k - 1) * (k - 1) * (k - 1) * (k - 1) * ((13 * k * k) + (k - 1))));

            }
            Console.WriteLine(result);

        }
    }
}
