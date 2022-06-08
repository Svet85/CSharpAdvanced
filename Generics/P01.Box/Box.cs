using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            data = new List<T>();
        }
        public int Count => this.data.Count;
        public void Add(T item)
        {
            this.data.Add(item);
        }

        public T Remove()
        {
            var removed = this.data.Last();
            data.RemoveAt(data.Count - 1);
            return removed;
        }
    }
}
