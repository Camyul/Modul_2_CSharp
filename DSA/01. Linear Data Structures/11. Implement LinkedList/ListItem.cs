using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Implement_LinkedList
{
    internal class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public ListItem<T> PrevItem { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }


    }
}
