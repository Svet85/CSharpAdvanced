using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToPush = parameters[0];
            int elementsoPop = parameters[1];
            int checkNumber = parameters[2];
            int[] arrayNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                numbers.Push(arrayNumbers[i]);
            }

            for (int i = 0; i < elementsoPop; i++)
            {
                if (numbers.Count == 0)
                {
                    break;
                }

                numbers.Pop();
            }

            if (numbers.Contains(checkNumber))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
