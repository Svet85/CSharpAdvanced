using System;
using System.Collections.Generic;

namespace P01.ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> inputParts = new Stack<string>();

            foreach (var @char in input)
            {
                inputParts.Push(@char.ToString());
            }

            foreach (var @string in inputParts)
            {
                Console.Write(@string);
            }
        }
    }
}
