using System;
using System.Linq;

namespace CustomComperator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] aray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> customComparer = (x, y) => x > y ? 1 : x < y ? -1 : 0;
            Func<int, int, int> orderComparer = (x, y) => (x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0) ? customComparer(x, y) : x % 2 != 0 ? 1 : -1;
            Array.Sort(aray, (x, y) => orderComparer(x, y));
            Console.WriteLine(string.Join(" ", aray));
        }
    }
}
