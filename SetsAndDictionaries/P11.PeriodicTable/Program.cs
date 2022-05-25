using System;
using System.Collections.Generic;

namespace P11.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                for (int k = 0; k < info.Length; k++)
                {
                    elements.Add(info[k]);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
