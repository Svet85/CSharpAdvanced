using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            
            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] cmdArgs = input.Split();
                string action = cmdArgs[0];

                if (action == "add")
                {
                    int number_1 = int.Parse(cmdArgs[1]);
                    int number_2 = int.Parse(cmdArgs[2]);

                    stack.Push(number_1);
                    stack.Push(number_2);
                }
                else if (action == "remove")
                {
                    int countOfNumbersToRemove = int.Parse(cmdArgs[1]);

                    if (stack.Count >= countOfNumbersToRemove)
                    {
                        for (int i = 0; i < countOfNumbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            int sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
