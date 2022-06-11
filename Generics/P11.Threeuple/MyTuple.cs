using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class MyTuple<T1, T2, T3>
    {
        public MyTuple()
        {

        }
        public MyTuple(T1 value_1, T2 value_2, T3 value_3)
        {
            Value_1 = value_1;
            Value_2 = value_2;
            Value_3 = value_3;
        }

        public T1 Value_1 { get; set; }
        public T2 Value_2 { get; set; }
        public T3 Value_3 { get; set; }

        public override string ToString()
        {
            return $"{Value_1} -> {Value_2} -> {Value_3}";
        }
    }
}
