using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Sorting
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            int answer = Solve(nums, k);
            Console.WriteLine(answer);
        }

        private static int Solve(int[] nums, int k)
        {
            var visited = new Dictionary<int, int>();

            var queue = new Queue<int[]>();
            queue.Enqueue(nums);
            visited.Add(GetHashCode(nums), 0);

            while (queue.Count > 0)
            {
                var currentPerm = queue.Dequeue();
                var currentPath = visited[GetHashCode(currentPerm)];
                if (IsSorted(currentPerm))
                {
                    return currentPath;
                }

                for (int i = 0; i <= nums.Length - k; i++)
                {
                    var desc = currentPerm.Clone() as int[];
                    Array.Reverse(desc, i, k);
                    if (!visited.ContainsKey(GetHashCode(desc)))
                    {
                        visited.Add(GetHashCode(desc), currentPath + 1);
                        queue.Enqueue(desc);
                    }
                }
            }
            return -1;
        }

        static int GetHashCode(int[] values)
        {
            int hash = 0;
            foreach (var val in values)
            {
                hash *= 8;
                hash += val;
            }

            return hash;                                                        
        }

        static bool IsSorted(int[] perm)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] < perm[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
