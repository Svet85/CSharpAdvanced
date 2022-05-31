using System;
using System.Linq;

namespace P09.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] borders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Predicate<int> filter = Filter(command);

            for (int i = borders[0]; i <= borders[1]; i++)
            {
                if (filter(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static Predicate<int> Filter(string command)
        {
            if (command == "odd")
            {
                return x => x % 2 != 0;
            }
            else if(command == "even")
            {
                return x => x % 2 == 0;
            }
            else
            {
                return null;
            }
        }
    }
}
