using System;

namespace P07.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = x => Console.WriteLine("Sir" + " " + x);
            Array.ForEach(names, print);
        }
    }
}
