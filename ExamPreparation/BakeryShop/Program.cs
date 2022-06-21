using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));
            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                ["Croissant"] = 0,
                ["Muffin"] = 0,
                ["Baguette"] = 0,
                ["Bagel"] = 0,

            };
            while (water.Count > 0 && flour.Count > 0)
            {
                double waterUsed = water.Dequeue();
                double flourUsed = flour.Pop();
                string bakedproduct = BakingProduct(waterUsed, flourUsed);
                
                if (bakedproduct == "bestProduct")
                {
                    bakedproduct = "Croissant";
                    double flourLeftToPush = flourUsed - waterUsed;
                    flour.Push(flourLeftToPush);
                }
                
                products[bakedproduct]++;
            }

            foreach (var product in products.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            string waterLeft = water.Count == 0 ? "Water left: None" : $"Water left: {string.Join(", ", water)}";
            string flourLeft = flour.Count == 0 ? "Flour left: None" : $"Flour left: {string.Join(", ", flour)}";
            Console.WriteLine(waterLeft);
            Console.WriteLine(flourLeft);
        }

        public static string BakingProduct(double waterUsed, double flourUsed)
        {
            string product = "";
            double waterPercent = waterUsed / (waterUsed + flourUsed) * 100;
            switch (waterPercent)
            {
                case 50:
                    product = "Croissant";
                    break;
                case 40:
                    product = "Muffin";
                    break;
                case 30:
                    product = "Baguette";
                    break;
                case 20:
                    product = "Bagel";
                    break;
                default:
                    product = "bestProduct";
                    break;
            }

            return product;
        }
    }
}
