using System;
using System.Linq;

namespace P11.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());
            bool div(int x) => x % divider != 0;
            Array.Reverse(nums);
            nums = nums.Where(div).ToArray();
            Console.WriteLine(string.Join(" ", nums));
        }

    }
}
