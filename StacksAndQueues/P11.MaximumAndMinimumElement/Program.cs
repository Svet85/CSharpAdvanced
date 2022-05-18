using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (cmd[0] == 1)
                {
                    numbers.Push(cmd[1]);
                }
                else if (cmd[0] == 2)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (cmd[0] == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max()); ;
                    }
                }
                else if (cmd[0] == 4)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", numbers));
            }

        }
    }
}
