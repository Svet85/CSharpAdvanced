using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public Stack(T[] elements)
        {
            this.collection = new List<T>(elements);
        }

        public void Push(T element)
        {
            collection.Add(element);
        }

        public void Pop()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            collection.RemoveAt(collection.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
