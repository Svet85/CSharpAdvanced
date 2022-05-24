using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> occurences = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!occurences.ContainsKey(num))
                {
                    occurences.Add(num, 0);
                }

                occurences[num]++;
            }

            foreach (var item in occurences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
