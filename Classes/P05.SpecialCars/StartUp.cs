using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresSets = new List<Tire[]>();

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] tiresInfo = input.Split();
                var tires = new Tire[tiresInfo.Length / 2];
                
                for (int i = 0, k = 0; i < tiresInfo.Length; i += 2, k++)
                {
                    var tire = new Tire();
                    tire.Year = int.Parse(tiresInfo[i]);
                    tire.Pressure = double.Parse(tiresInfo[i + 1]);

                    tires[k] = tire;
                }
                tiresSets.Add(tires);

                input = Console.ReadLine();
            }

            List<Engine> engineSets = new List<Engine>();

            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] engineInfo = input.Split();
                int HP = int.Parse(engineInfo[0]);
                double CC = double.Parse(engineInfo[1]);
                var engine = new Engine(HP, CC);
                engineSets.Add(engine);

                input = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineSets[engineIndex], tiresSets[tiresIndex]);
                cars.Add(car);

                input = Console.ReadLine();
            }

            var specialCars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && (x.Tires.Sum(x => x.Pressure) > 9 && x.Tires.Sum(x => x.Pressure) < 10)).ToList();
            
            foreach (var car in specialCars)
            {
                car.Drive(20);
            }

            foreach (var car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }

        }
    }
}
