using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Businessmen
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[] solutions = new long[71];
            solutions[0] = 1;

            for (int allPeople = 2; allPeople <= n; allPeople += 2)
            {
                for (int oneSidePeople = allPeople - 2; oneSidePeople >= 0; oneSidePeople -= 2)
                {
                    solutions[allPeople] += solutions[oneSidePeople] * solutions[allPeople - oneSidePeople - 2];
                }
            }

            Console.WriteLine(solutions[n]);
        }
    }
}
