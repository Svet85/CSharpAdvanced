using System;
using System.Collections.Generic;

namespace P07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            while (children.Count > 1)
            {
                counter++;

                if (counter == n)
                {
                    string child = children.Dequeue();
                    Console.WriteLine($"Removed {child}");
                    counter = 0;
                }
                else
                {
                    string child = children.Dequeue();
                    children.Enqueue(child);
                }
            }

            Console.WriteLine($"Last is {children.Peek()}");
        }
    }
}
