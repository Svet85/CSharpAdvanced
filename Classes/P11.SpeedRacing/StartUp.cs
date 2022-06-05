using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Car> cars = new List<Car>();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string model = info[0];
                double fuel = double.Parse(info[1]);
                double fuelConsumption = double.Parse(info[2]);

                cars.Add(new Car(model, fuel, fuelConsumption));
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split();
                string model = info[1];
                int KM = int.Parse(info[2]);
                Car car = cars.Find(x => x.Model == model);
                car.Drive(KM);
                
                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
