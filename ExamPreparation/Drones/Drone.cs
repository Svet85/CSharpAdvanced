using System;
using System.Text;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; } = true;

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Drone: {this.Name}");
            text.AppendLine($"Manufactured by: {this.Brand}");
            text.Append($"Range: {this.Range} kilometers");
            return text.ToString();
        }
    }
}
