using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualiltyScale<T>
    {
        private T left;
        private T right;
        public EqualiltyScale(T left, T right)
        {
            this.right = right;
            this.left = left;
        }

        public bool AreEqual()
        {
            bool result = this.left.Equals(this.right);
            return result;
        }
    }
}
