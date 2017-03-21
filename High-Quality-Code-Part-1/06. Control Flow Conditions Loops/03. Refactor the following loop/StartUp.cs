using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_the_following_loop
{
    public class StartUp
    {
        public static void Main()
        {
            int i = 0;
            int arrayLength = 100;
            int[] array = new int[arrayLength];
            int expectedValue = 5;

            for (i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
            }
            //// More code here
        }
    }
}
