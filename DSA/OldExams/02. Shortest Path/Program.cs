﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Shortest_Path
{
    public class Program
    {
        private static char[] map;

        private static SortedSet<string> result = new SortedSet<string>();

        public static void Find(int index)
        {
            if (index == map.Length)
            {
                result.Add(new string(map));
            }
            else if(map[index] != '*')
            {
                Find(index + 1);
            }
            else
            {
                map[index] = 'S';
                Find(index + 1);
                map[index] = 'L';
                Find(index + 1);
                map[index] = 'R';
                Find(index + 1);
                map[index] = '*';
            }

        }

        static void Main()
        {
            map = Console.ReadLine().ToCharArray();

            Find(0);
            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
