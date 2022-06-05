using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Cargo
    {
        public Cargo()
        {

        }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        
        public int Weight { get; set; }
        public string Type { get; set; }

    }
}
