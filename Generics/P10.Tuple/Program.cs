using System;
using System.Collections.Generic;

namespace Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string name = new string(array[0] + " " + array[1]);
            string address = array[2];
            var tuple = new MyTuple<object, object>(name, address);

            string[] array_2 = Console.ReadLine().Split();
            string name_2 = array_2[0];
            int litters = int.Parse(array_2[1]);
            var tuple_2 = new MyTuple<object, object>(name_2, litters);

            string[] array_3 = Console.ReadLine().Split();
            int value_1 = int.Parse(array_3[0]);
            double value_2 = double.Parse(array_3[1]);
            var tuple_3 = new MyTuple<object, object>(value_1, value_2);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple_2);
            Console.WriteLine(tuple_3);
        }
    }
}
