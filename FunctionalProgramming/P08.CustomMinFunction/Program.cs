using System;
using System.Linq;

namespace P08.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> minNumber = x => x.Min();
            Console.WriteLine(minNumber(numbers));
        }

    }
}
