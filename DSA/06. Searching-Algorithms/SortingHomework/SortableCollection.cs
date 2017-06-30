using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> collection;

        public SortableCollection(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
        }

        public IList<T> Collection
        {
            get
            {
                return this.collection;
            }
        }

        public int BinarySearch(T item, int left, int right)
        {

            while (left < right)
            {
                int middle = (left + right) / 2;
                int cmp = this.Collection[middle].CompareTo(item);

                if (cmp < 0)
                {
                    left = middle + 1;
                }
                else if (cmp > 0)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }

            }

            return -1;
        }
    }
}
