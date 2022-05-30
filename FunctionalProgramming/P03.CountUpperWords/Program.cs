using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.CountUpperWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsUpper(x[0])).ToList();
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
