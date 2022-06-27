using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dishes = new SortedDictionary<string, int>()
            {
                ["Dipping sauce"] = 0,
                ["Green salad"] = 0,
                ["Chocolate cake"] = 0,
                ["Lobster"] = 0,
            };

            Queue<int> products = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (products.Count > 0 && freshness.Count > 0)
            {
                if (products.Peek() == 0)
                {
                    products.Dequeue();
                    continue;
                }

                int product = products.Dequeue();
                int prodFreshness = freshness.Pop();
                int freshnessLevel = product * prodFreshness;

                string dish = CheckDish(freshnessLevel);

                if (dish == "failed")
                {
                    products.Enqueue(product + 5);
                }
                else
                {
                    dishes[dish]++;
                }
            }

            if (dishes.Count(x => x.Value > 0) == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (products.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {products.Sum()}");
            }

            foreach (var dish in dishes.Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }

        public static string CheckDish(int freshnessLevel)
        {
            string dish = "";

            switch (freshnessLevel)
            {
                case 150:
                    dish = "Dipping sauce";
                    break;
                case 250:
                    dish = "Green salad";
                    break;
                case 300:
                    dish = "Chocolate cake";
                    break;
                case 400:
                    dish = "Lobster";
                    break;
                default:
                    dish = "failed";
                    break;
            }

            return dish;
        }
    }
}
