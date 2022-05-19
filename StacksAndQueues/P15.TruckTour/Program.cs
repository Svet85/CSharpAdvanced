using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P15.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(info);
            }


            for (int i = 0; i < numberOfPumps; i++)
            {
                bool flag = true;
                BigInteger tank = 0;

                foreach (var pump in pumps)
                {
                    tank += pump[0];
                    int distance = pump[1];

                    if (distance > tank)
                    {
                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        flag = false;
                        break;
                    }
                    else
                    {
                        tank -= distance;
                    }
                }

                if (flag)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
