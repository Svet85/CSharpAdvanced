using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {

        public Car()
        {
            TravelledDistance = 0.0;
        }

        public Car(string model, double fuelAmount, double fuelConsumption) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
        }
        
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelAmount < this.FuelConsumptionPerKilometer * distance)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * distance;
                this.TravelledDistance += distance;
            }
        }

        public override string ToString()
        {
            return @$"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
