using System;
using System.Collections.Generic;

namespace P04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> index = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    index.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startingIndex = index.Pop();

                    string substring = expression.Substring(startingIndex, i - startingIndex + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
