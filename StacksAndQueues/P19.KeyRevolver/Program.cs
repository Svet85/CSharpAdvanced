using System;
using System.Collections.Generic;
using System.Linq;

namespace P19.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int shotsCounter = 0;
            int totalBullets = bullets.Count;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                shotsCounter++;

                if (barrelSize == shotsCounter && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shotsCounter = 0;
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int earnedMoney = intelligenceValue - ((totalBullets - bullets.Count) * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            }
        }
    }
}
