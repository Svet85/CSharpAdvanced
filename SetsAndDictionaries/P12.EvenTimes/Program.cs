using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (nums.ContainsKey(num) == false)
                {
                    nums.Add(num, 0);
                }

                nums[num]++;
            }

            foreach (var item in nums.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
