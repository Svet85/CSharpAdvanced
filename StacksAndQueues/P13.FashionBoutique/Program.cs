using System;
using System.Collections.Generic;
using System.Linq;

namespace P13.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> box = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int counter = 0;

            while (box.Count > 0)
            {
                counter++;

                if (rackCapacity == box.Peek())
                {
                    box.Pop();
                }
                else
                {
                    int currentRack = rackCapacity;

                    while (box.Count > 0 && currentRack >= box.Peek())
                    {
                        currentRack -= box.Pop();
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
