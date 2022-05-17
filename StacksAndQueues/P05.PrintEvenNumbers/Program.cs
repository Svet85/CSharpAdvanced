using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int originalLen = numbers.Count;

            for (int i = 0; i < originalLen; i++)
            {
                int number = numbers.Peek();

                if (number % 2 == 0)
                {
                    numbers.Enqueue(number);
                    numbers.Dequeue();
                }
                else
                {
                    numbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
