using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToEnqueue = parameters[0];
            int elementsoDequeue = parameters[1];
            int checkNumber = parameters[2];
            int[] arrayNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                numbers.Enqueue(arrayNumbers[i]);
            }

            for (int i = 0; i < elementsoDequeue; i++)
            {
                if (numbers.Count == 0)
                {
                    break;
                }

                numbers.Dequeue();
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
