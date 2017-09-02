using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.A_Box_Full_of_Balls
{
    class Program
    {
        static void Main()
        {
            int[] moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = ab[0];
            int b = ab[1];

            
            var isWins = new bool[b + 1];
            isWins[0] = false;
            for (int i = 1; i <= b; i++)
            {
                foreach (var move in moves)
                {
                    if (move > i)
                    {
                        continue;
                    }
                    if (!isWins[i - move])
                    {
                        isWins[i] = true;
                    }
                }
            }

            int total = 0;
            for (int i = a; i <= b; i++)
            {
                if (isWins[i])
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }
    }
}
