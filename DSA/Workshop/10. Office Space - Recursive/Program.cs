using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Office_Space___Recursive
{
    class Program
    {                   // 92/100
        static int[] answers = new int[50];
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int>[] dependencies = new List<int>[n];


            for (int i = 0; i < n; i++)
            {
                dependencies[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToList();
            }

            for (int i = 0; i < n; i++)
            {
                answers[i] = CalcMinTime(i, minutes, dependencies);
            }

            Console.WriteLine(answers.Max());
        }

        static int CalcMinTime(int taskId, int[] minutes, List<int>[] dependencies)
        {
            if (answers[taskId] != 0)
            {
                return answers[taskId];
            }

            if (dependencies[taskId].Count == 1 && dependencies[taskId][0] == -1)
            {
                return minutes[taskId];
            }

            int maxDependecyTime = 0;
            foreach (int dependencyId in dependencies[taskId])
            {
                var dependecyTime = CalcMinTime(dependencyId, minutes, dependencies);

                maxDependecyTime = Math.Max(dependecyTime, maxDependecyTime);
            }

            answers[taskId] = minutes[taskId] + maxDependecyTime;

            return answers[taskId];
        }
    }
}
