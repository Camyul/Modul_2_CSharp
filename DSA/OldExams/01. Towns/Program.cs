using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Towns
{
    class Program
    {
        static void Main()
        {
            int numberOfTowns = int.Parse(Console.ReadLine());
            List<int> peoples = new List<int>();

            for (int i = 0; i < numberOfTowns; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                peoples.Add(int.Parse(nums[0]));
            }

            int answer = Solve(peoples);
            Console.WriteLine(answer);
        }

        private static int Solve(List<int> nums)
        {
            // пресмятаме максимално нарастваща поредица и записваме
            // за всеки елемент дължината на поредицата в масив
            int[] leftToRight = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLength = Math.Max(maxLength, leftToRight[j]);
                    }
                }

                leftToRight[i] = maxLength + 1;
            }

            // пресмятаме максимално нарастваща поредица отзад на пред и записваме
            // за всеки елемент дължината на поредицата в масив
            int[] rightToLeft = new int[nums.Count];
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                int maxLength = 0;
                for (int j = nums.Count -1; j > i; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLength = Math.Max(maxLength, rightToLeft[j]);
                    }
                }

                rightToLeft[i] = maxLength + 1;
            }

            // комбинираме двата масива и намираме маьсималния отговор
            int maxPath = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                int path = leftToRight[i] + rightToLeft[i] - 1;
                maxPath = Math.Max(path, maxPath);
            }

            return maxPath;
        }
    }
}
