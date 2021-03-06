using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfIntegers
{
    public class Box<T>
    {
        public Box()
        {

        }
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
