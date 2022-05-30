using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.2).ToList();
            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
