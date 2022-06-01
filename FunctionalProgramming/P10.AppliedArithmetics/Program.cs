using System;
using System.Linq;

namespace P10.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int> addition = x => x + 1;
            Func<int, int> myltipllication = x => x * 2;
            Func<int, int> subtraction = x => x - 1;
            Func<int[], string> print = x => string.Join(" ", x);


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "add")
                {
                    nums = nums.Select(addition).ToArray();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(myltipllication).ToArray();
                }
                else if (command == "subtract")
                {
                    nums = nums.Select(subtraction).ToArray();

                }
                else if (command == "print")
                {
                    Console.WriteLine(print(nums));
                }
                else if (command == "end")
                {
                    break;
                }
            }

        }
    }
}
