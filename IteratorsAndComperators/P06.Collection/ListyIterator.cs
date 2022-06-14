using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
