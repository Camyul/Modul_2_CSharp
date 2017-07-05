using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipe
{
    public static class StartUp
    {
        public static void Main()
        {
            int numberPipes = int.Parse(Console.ReadLine());
            int numberFighters = int.Parse(Console.ReadLine());
            long[] pipes = new long[numberPipes];

            for (int i = 0; i < numberPipes; i++)
            {
                pipes[i] = long.Parse(Console.ReadLine());
            }

            long devider = pipes.Sum() / numberFighters;

            long count = 0;
            long min = 0;
            long max = devider;

            while (count != numberFighters)
            {
                count = 0;
                    devider = (min + max) / 2;
                for (int i = 0; i < numberPipes; i++)
                {
                    count += pipes[i] / devider;
                }

                if (count < numberFighters)
                {
                    max = devider;
                }
                else if (count > numberFighters)
                {

                    min = devider;
                }
            }

            while (count == numberFighters)
            {
                count = 0;
                ++devider;
                for (int i = 0; i < numberPipes; i++)
                {
                    count += pipes[i] / devider;
                }
            }

            Console.WriteLine(--devider);
        }
    }
}


