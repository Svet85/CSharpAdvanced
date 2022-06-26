using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps,int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            foreach (var _car in Participants)
            {
                if (_car.LicensePlate == car.LicensePlate)
                {
                    return;
                }
            }

            if (car.HorsePower > this.MaxHorsePower || Participants.Count + 1 > Capacity) 
            {
                return;
            }

            Participants.Add(car);
        }
        public bool Remove(string licensePlate)
        {
            Car car = null;
            foreach (var _car in Participants)
            {
                if (_car.LicensePlate == licensePlate)
                {
                    car = _car;
                }
            }

            return Participants.Remove(car);
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = null;

            foreach (var _car in Participants)
            {
                if (_car.LicensePlate == licensePlate)
                {
                    car = _car;
                }
            }

            return car;
        }

        public Car GetMostPowerfulCar()
        {
            Car car = null;
            int HP = 0;

            foreach (var _car in Participants)
            {
                if (_car.HorsePower > HP)
                {
                    car = _car;
                    HP = _car.HorsePower;
                }
            }

            return car;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps}){Environment.NewLine}{string.Join(Environment.NewLine, this.Participants)}");

            return text.ToString();
        }
    }
}
