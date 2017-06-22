using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Implement_LinkedList
{
    internal static class StartUp
    {
        static void Main()
        {
            var doubleLinkedList = new DoubleLinkedList<int>();

            while (true)
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    doubleLinkedList.AddFirst(i);
                //}

                //for (int i = 0; i < 8; i++)
                //{
                //    doubleLinkedList.InsertAfter(doubleLinkedList.FirstElement, i + 10);
                //}

                var command = Console.ReadLine().Split(' ');
                if (command[0] == "pf")
                {
                    doubleLinkedList.AddFirst(int.Parse(command[1]));
                }

                else if (command[0] == "pb")
                {
                    doubleLinkedList.AddLast(int.Parse(command[1]));
                }
                else if (command[0] == "rf")
                {
                    doubleLinkedList.RemoveFirst();
                }
                else if (command[0] == "rb")
                {
                    doubleLinkedList.RemoveLast();

                }
                else if (command[0] == "r")
                {
                    var node = doubleLinkedList.FirstElement;

                    var index = int.Parse(command[1]);
                    for (int i = 0; i < index; i++)
                    {
                        node = node.NextItem;
                    }
                    doubleLinkedList.Remove(node);

                }

                var line = new StringBuilder();
                for (var node = doubleLinkedList.FirstElement; node != null; node = node.NextItem)
                {
                    line.Append($" {node.Value}");
                }
                    Console.WriteLine(line);
            }

            
        }
    }
}
