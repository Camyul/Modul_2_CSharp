using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    public class Node
    {
        public Node(int value)
        {
            this.Workers = new HashSet<Node>();
            this.Value = value;
        }

        public HashSet<Node> Workers { get; set; }
        public int Value { get; set; }
        public int Salary
        {
            get
            {
                int totalSalary = 0;
                if (this.Workers.Count == 0)
                {
                    totalSalary = 1;
                }
                foreach (var worker in this.Workers)
                {
                    totalSalary += worker.Salary;
                }
                return totalSalary;
            }
        }
    }

    public class StartUp
    {
        static void Main()
        {
            //int numberOfWorkes = int.Parse(Console.ReadLine());
            int numberOfWorkes = 8;
            Dictionary<int, Node> workers = new Dictionary<int, Node>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < numberOfWorkes; i++)
            {
                workers.Add(i, new Node(i));
            }
            sw.Stop();
            Console.WriteLine("Add workers: {0}", sw.ElapsedTicks);
            sw.Reset();

            string input = @"NNNNNN
YNYNNYNN
YNNNNYYN
NNNNNNYN
YNYNNNYY
YNNYNNYY
NNYYNYNN
NNNNNNNN";
            string[] rows = input.Split('\n').ToArray();

            sw.Start();
            for (int i = 0; i < numberOfWorkes; i++)
            {
                //string row = Console.ReadLine();
                string row = rows[i];
                int index = 0;
                while (index >= 0)
                {
                    index = row.IndexOf("Y", index);
                    if (index < 0)
                    {
                        break;
                    }

                    workers[i].Workers.Add(workers[index]);

                    ++index;
                }  
                
            }
            sw.Stop();
            Console.WriteLine("Read from Console: {0}", sw.ElapsedTicks);
            sw.Reset();

            sw.Start();
            int result = 0;
            for (int i = 0; i < numberOfWorkes; i++)
            {
                result += workers[i].Salary;
            }
            sw.Stop();
            Console.WriteLine("Calculate Salary: {0}", sw.ElapsedTicks);
            sw.Reset();
            Console.WriteLine(result);
        }
    }
}
/*
4
NNYN
NNYN
NNNN
NYYN

6
NNNNNN
YNYNNY
YNNNNY
NNNNNN
YNYNNN
YNNYNN

*/
