using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {

        }
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public int CompareTo([AllowNull] T other)
        {
            return this.Value.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
