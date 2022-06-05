using System;
using System.Collections.Generic;
using System.Linq;

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
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = info[0];
                var engine = new Engine(int.Parse(info[1]), int.Parse(info[2]));
                var cargo = new Cargo(int.Parse(info[3]), info[4]);
                string[] tires = info.TakeLast(8).ToArray();
                var tireSets = new Tire[4];

                for (int k = 0, j = 0; k < tires.Length; k += 2, j++)
                {
                    tireSets[j] = new Tire(int.Parse(tires[k + 1]), double.Parse(tires[k]));
                }

                var car = new Car(carModel, engine, cargo, tireSets);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();
            if (cmd == "fragile")
            {
                foreach (var car in cars.FindAll(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (cmd == "flammable")
            {
                foreach (var car in cars.FindAll(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
