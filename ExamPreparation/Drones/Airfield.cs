using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public IReadOnlyList<Drone> Drones => this.drones;
        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || (drone.Range < 5 || drone.Range > 15))
            {
                return "Invalid drone.";
            }

            if (this.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var drone = this.Drones.FirstOrDefault(x => x.Name == name);
            return this.drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.drones.RemoveAll(x => x.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var drone = this.Drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flown = this.drones.Where(x => x.Range >= range).ToList();
            foreach (var drone in flown)
            {
                drone.Available = false;
            }

            return flown;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Drones available at {this.Name}:");
            text.AppendJoin(Environment.NewLine, this.drones.Where(x => x.Available == true));
            return text.ToString();
        }

    }
}
