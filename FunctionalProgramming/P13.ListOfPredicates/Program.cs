using System;
using System.Collections.Generic;
using System.Linq;

namespace P13.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();


            for (int i = 1; i <= end; i++)
            {
                bool flag = true;

                foreach (var div in dividers)
                {
                    Predicate<int> check = i => i % div == 0;
                    if (!check(i))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));


        }
    }
}
