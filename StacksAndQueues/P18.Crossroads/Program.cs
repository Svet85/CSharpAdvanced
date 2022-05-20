using System;
using System.Collections.Generic;

namespace P18.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else if(cars.Count > 0)
                {
                    int carLen = cars.Peek().Length;

                    if (greenLightDuration > carLen)
                    {
                        carsPassed++;
                        cars.Dequeue();

                        int greenLeft = greenLightDuration - carLen;

                        while (cars.Count > 0)
                        {
                            if (cars.Peek().Length < greenLeft)
                            {
                                carsPassed++;
                                greenLeft -= cars.Dequeue().Length;
                            }
                            else if(cars.Peek().Length <= greenLeft + freeWindow)
                            {
                                carsPassed++;
                                cars.Dequeue();
                                break;
                            }
                            else
                            {
                                int index = greenLeft + freeWindow;
                                char hit = cars.Peek()[index];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Peek()} was hit at {hit}.");
                                Environment.Exit(0);
                            }
                        }
                    }
                    else if (greenLightDuration + freeWindow >= carLen)
                    {
                        carsPassed++;
                        cars.Dequeue();
                    }
                    else
                    {
                        int index = greenLightDuration + freeWindow;
                        char hit = cars.Peek()[index];

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{cars.Peek()} was hit at {hit}.");
                        Environment.Exit(0);
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
