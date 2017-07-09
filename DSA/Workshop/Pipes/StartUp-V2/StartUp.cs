using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_V2
{
    class StartUp
    {
        static void Main()
        {
            int numberPipes = int.Parse(Console.ReadLine());
            int numberFighters = int.Parse(Console.ReadLine());
            int[] pipes = new int[numberPipes];

            for (int i = 0; i < numberPipes; i++)
            {
                pipes[i] = int.Parse(Console.ReadLine());
            }

            int result = BinarySearch(pipes, numberFighters, 0, 2000000000);
            Console.WriteLine(result);
        }

        private static bool ChechSize(int[] pipes, int numberFighters, int size)
        {
            long pipeCount = 0;

            foreach (var pipe in pipes)
            {
                pipeCount += pipe / size;
            }

            return pipeCount >= numberFighters;
        }

        private static int BinarySearch(int[] pipes, int numberFighters, int left, int right)
        {
            while (left == right)
            {
                return left - 1; //дъното на ракурсията
            }

            int middle = (left + right) / 2;

            if (ChechSize(pipes, numberFighters, middle))
            {
                return BinarySearch(pipes, numberFighters, middle + 1, right);
            }
            else
            {
                return BinarySearch(pipes, numberFighters, 0, middle);
            }
        }
    }
}
