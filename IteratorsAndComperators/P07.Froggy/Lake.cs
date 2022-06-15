using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> collection;

        public Lake(int[] elements)
        {
            this.collection = new List<int>(elements);
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i += 2)
            {
                yield return collection[i];
            }

            if (collection.Count % 2 == 0)
            {
                for (int i = collection.Count - 1; i >= 0; i -= 2)
                {
                    yield return collection[i];
                }
            }
            else
            {
                for (int i = collection.Count - 2; i >= 0; i -= 2)
                {
                    yield return collection[i];
                }
            }
            


        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
