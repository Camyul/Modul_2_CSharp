﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Removes_all_negative_numbers
{
    public class StartUp
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(4);
            linkedList.AddLast(-1);
            linkedList.AddFirst(-4);
            linkedList.AddFirst(2);
            LinkedListNode<int> element = linkedList.Find(-1);
            linkedList. AddBefore(element , 8);
            linkedList. AddBefore(element , -58);
            linkedList. AddBefore(element, -68);
            string.Join(", ", linkedList);
            //foreach (var node in linkedList)
            //{
            //    if (node < 0)
            //    {
            //        linkedList.Remove(node);
            //    }
            //}

            string.Join(", ", linkedList);

        }
    }
}
