using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackAndQueue
{
    public class MyList
    {
        private const int InitialCapacity = 4;
        private int[] collection;
        public MyList()
        {
            collection = new int[InitialCapacity];
        }
        public int Capacity => collection.Length;
        public int Count { get; private set; }
        public int this[int i]
        {
            get 
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return collection[i]; 
            }
            set 
            {
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                collection[i] = value; 
            }
        }

        public void AddElement(int element)
        {
            if (Count == Capacity - 2)
            {
                int[] resizedArray = new int[Capacity * 2];
                for (int i = 0; i < Count; i++)
                {
                    resizedArray[i] = collection[i];
                }
                collection = resizedArray;
            }

            collection[Count] = element;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            
            Count--;

            int removedElement = collection[index];
            for (int i = index; i < Count; i++)
            {
                collection[i] = collection[i + 1];
            }

            return removedElement;
        }
    }
}

