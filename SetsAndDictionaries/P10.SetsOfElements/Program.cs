using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> set_1 = new HashSet<int>(array[0]);
            HashSet<int> set_2 = new HashSet<int>(array[1]);

            for (int i = 0; i < array.Sum(); i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (i < array[0])
                {
                    set_1.Add(num);
                }
                else
                {
                    set_2.Add(num);
                }
            }

            HashSet<int> uniqueNum = new HashSet<int>();

            foreach (var num in set_1)
            {
                if (set_2.Contains(num))
                {
                    uniqueNum.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueNum));
        }
    }
}
