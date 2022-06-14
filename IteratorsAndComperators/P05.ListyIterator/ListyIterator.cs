using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int internalIndex;
        public ListyIterator(T[] elements)
        {
            collection = new List<T>(elements);
        }

        public bool Move()
        {
            bool canMove = internalIndex < collection.Count - 1;
            if (canMove)
            {
                internalIndex++;
            }

            return canMove;
        }

        public bool HasNext()
        {
            return internalIndex < collection.Count - 1;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[internalIndex]);
        }

    }
}
