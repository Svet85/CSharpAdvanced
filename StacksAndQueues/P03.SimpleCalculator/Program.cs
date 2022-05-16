using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> expression = new Stack<string>(Console.ReadLine().Split().Reverse());

            int sum = 0;
            sum += int.Parse(expression.Pop());

            while (expression.Count > 0)
            {
                string @operator = expression.Pop();

                if (@operator == "+")
                {
                    sum += int.Parse(expression.Pop());
                }
                else
                {
                    sum -= int.Parse(expression.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
