using System;
using System.Collections.Generic;

namespace P07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> licensePlates = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] info = input.Split(", ");
                string direction = info[0];
                string plate = info[1];

                if (direction == "IN")
                {
                    licensePlates.Add(plate);
                }
                else if (direction == "OUT")
                {
                    licensePlates.Remove(plate);
                }

                input = Console.ReadLine();
            }

            if (licensePlates.Count > 0)
            {
                foreach (var plate in licensePlates)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
