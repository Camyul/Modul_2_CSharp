using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Implement_LinkedList
{
    internal class DoubleLinkedList<T> : IEnumerable<T>
    {
        public DoubleLinkedList()
        {
            
        }

        public DoubleLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException("Seed collection cannot be null.");
            }

            collection
                .ToList()
                .ForEach(item => this.AddLast(item));
        }

        public ListItem<T> FirstElement { get; private set; }

        public ListItem<T> LastElement { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            ListItem<T> linkedListNode = new ListItem<T>(item);

            if (this.FirstElement == null)
            {
                this.FirstElement = this.LastElement = linkedListNode;
            }
            else
            {
                linkedListNode.NextItem = this.FirstElement;
                this.FirstElement.PrevItem = linkedListNode;
                this.FirstElement = linkedListNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            ListItem<T> linkedListNode = new ListItem<T>(item);

            if (this.FirstElement == null)
            {
                this.FirstElement = this.LastElement = linkedListNode;
            }
            else
            {
                linkedListNode.PrevItem = this.LastElement;
                this.LastElement.NextItem = linkedListNode;
                this.LastElement = linkedListNode;
            }

            this.Count++;
        }

        public void InsertBefore(ListItem<T> node, T value)
        {
            this.Count++;

            var newNode = new ListItem<T>(value);
            newNode.NextItem = node;
            newNode.PrevItem = node.PrevItem;
            
            newNode.NextItem.PrevItem = newNode;

            if (newNode.PrevItem != null)
            {
                newNode.PrevItem.NextItem = newNode;
            }
            else
            {
                this.FirstElement = newNode;
            }
        }

        public void InsertAfter(ListItem<T> node, T value)
        {
            this.Count++;

            var newNode = new ListItem<T>(value);
            newNode.PrevItem = node;
            newNode.NextItem = node.NextItem;

            newNode.PrevItem.NextItem = newNode;

            if (newNode.NextItem != null)
            {
                newNode.NextItem.PrevItem = newNode;
            }
            else
            {
                this.LastElement = newNode;
            }
        }

        public void RemoveLast()
        {
            Remove(this.LastElement);
        }

        public void RemoveFirst()
        {
            Remove(this.FirstElement);
        }

        public void Remove(ListItem<T> item)
        {
            if (item.PrevItem != null)
            {
                item.PrevItem.NextItem = item.NextItem;
            }
            else
            {
                this.FirstElement = item.NextItem;
            }

            if (item.NextItem != null)
            {
                item.NextItem.PrevItem = item.PrevItem;
            }
            else
            {
                this.LastElement = item.PrevItem;
            }

            this.Count--;
            
        }

        public void ClearLinkedList()
        {
            this.FirstElement = null;
            this.LastElement = null;
            this.Count = 0;
        }

        public ListItem<T> FindNode(T item)
        {
            var currentNode = this.FirstElement;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return currentNode;
                }

                currentNode = currentNode.NextItem;
            }


            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.FirstElement;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
