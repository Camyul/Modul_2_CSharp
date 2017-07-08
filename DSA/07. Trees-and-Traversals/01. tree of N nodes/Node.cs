using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.tree_of_N_nodes
{
    public class Node<T>
    {
        public T Value { get; set; }

        public List<Node<T>> Cildren { get; set; }

        public bool HasParent { get; set; }

        public Node()
        {
            this.Cildren = new List<Node<T>>();
        }

        public Node(T value) : this()
        {
            this.Value = value;
        }
    }
}
