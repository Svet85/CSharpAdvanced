using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, bool> check = name => name.Length <= n;
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => check(x)).ToList();
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
