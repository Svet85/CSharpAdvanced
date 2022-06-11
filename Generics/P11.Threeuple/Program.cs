using System;
using System.Collections.Generic;
using System.Linq;

namespace Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string name = new string(array[0] + " " + array[1]);
            string address = array[2];
            string town = string.Join(" ", array.Skip(3));
            var tuple = new MyTuple<string, string, string>(name, address, town);

            string[] array_2 = Console.ReadLine().Split();
            string name_2 = array_2[0];
            int litters = int.Parse(array_2[1]);
            bool isDrunk = array_2[2] == "drunk";
            var tuple_2 = new MyTuple<string, int, bool>(name_2, litters, isDrunk);

            string[] array_3 = Console.ReadLine().Split();
            string value_1 = array_3[0];
            double value_2 = double.Parse(array_3[1]);
            string bank = array_3[2];
            var tuple_3 = new MyTuple<string, double, string>(value_1, value_2, bank);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple_2);
            Console.WriteLine(tuple_3);
        }
    }
}
