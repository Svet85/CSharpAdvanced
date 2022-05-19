using System;
using System.Collections.Generic;

namespace P16.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool flag = true;

            foreach (var ch in parantheses)
            {
                
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                    continue;
                }

                if (stack.Count == 0)
                {
                    flag = false;
                    break;
                }

                if ((ch == ')' && stack.Peek() != '(') || (ch == ']' && stack.Peek() != '[') || (ch == '}' && stack.Peek() != '{'))
                {
                    flag = false;
                    break;
                }

                stack.Pop();
            }

            if (flag && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
