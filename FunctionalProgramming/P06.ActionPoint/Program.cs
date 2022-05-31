using System;

namespace P06.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = x => Console.WriteLine(x);
            Array.ForEach(names, print);
        }
    }
}
