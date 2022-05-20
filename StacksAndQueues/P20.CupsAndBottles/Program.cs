using System;
using System.Collections.Generic;
using System.Linq;

namespace P20.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currentCup = cups.Peek();

                if (currentCup == bottles.Peek())
                {
                    cups.Dequeue();
                    bottles.Pop();
                }
                else if (currentCup < bottles.Peek())
                {
                    wastedWater += bottles.Pop() - currentCup;
                    cups.Dequeue();
                }
                else
                {
                    currentCup -= bottles.Pop();

                    while (bottles.Count > 0)
                    {
                        if (currentCup > bottles.Peek())
                        {
                            currentCup -= bottles.Pop();
                        }
                        else if (currentCup == bottles.Peek())
                        {
                            cups.Dequeue();
                            bottles.Pop();
                            break;
                        }
                        else
                        {
                            wastedWater += bottles.Pop() - currentCup;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
