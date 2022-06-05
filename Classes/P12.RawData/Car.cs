using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {


        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity < (this.FuelConsumption / 100) * distance)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= (this.FuelConsumption / 100) * distance;
            }
        }

        public string WhoAmI()
        {
            string info = $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";

            return info;
        }
    }
}
