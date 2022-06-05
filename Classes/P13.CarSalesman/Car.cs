using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {


        public Car(string model, Engine engine, int weight = -1, string color = null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(Model + ":");
            info.AppendLine("  " + Engine.Model + ":");
            info.AppendLine("    Power:" + " " + Engine.Power);
            if (Engine.Displacement == -1)
            {
                info.AppendLine("    Displacement: n/a");
            }
            else
            {
                info.AppendLine("    Displacement:" + " " + Engine.Displacement);
            }

            if (Engine.Efficiency == null)
            {
                info.AppendLine("    Efficiency: n/a");
            }
            else
            {
                info.AppendLine("    Efficiency:" + " " + Engine.Efficiency);
            }

            if (Weight == -1)
            {
                info.AppendLine("  Weight: n/a");
            }
            else
            {
                info.AppendLine("  Weight:" + " " + Weight);
            }

            if (Color == null)
            {
                info.Append("  Color: n/a");
            }
            else
            {
                info.Append("  Color:" + " " + Color);
            }

            return info.ToString();
        }
    }
}
