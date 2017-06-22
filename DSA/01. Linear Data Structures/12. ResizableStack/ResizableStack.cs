namespace _12.ResizableStack
{
    internal class ResizableStack<T>
    {
        private T[] data;

        public ResizableStack()
        {
            this.data = new T[4];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.data.Length;
            }
        }

        public void Push(T value)
        {
            if (this.Count == this.data.Length && this.Count > 0)
            {
                T[] newArray = new T[this.Capacity * 2];
                this.data.CopyTo(newArray, 0);
                this.data = newArray;
            }

            this.data[this.Count] = value;
            this.Count++;
        }

        public T Pop()
        {
            T result = this.data[this.Count - 1];
            this.Count--;

            return result;
        }
    }
}
