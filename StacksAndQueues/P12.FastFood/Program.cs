using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                int order = orders.Peek();

                if (order <= foodQuantity)
                {
                    foodQuantity -= order;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
