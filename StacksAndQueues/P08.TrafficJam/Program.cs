using System;
using System.Collections.Generic;

namespace P08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatCanPassOnGreen = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int counter = 0;
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green" && cars.Count >= carsThatCanPassOnGreen)
                {
                    for (int i = 0; i < carsThatCanPassOnGreen; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }

                    counter += carsThatCanPassOnGreen;
                }
                else if (input == "green" && cars.Count < carsThatCanPassOnGreen)
                {
                    while (cars.Count > 0)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
