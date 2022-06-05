using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine()
        {

        }

        public Engine(int speed, double power) : this()
        {
            this.Speed= speed;
            this.Power = power;
        }
        public int Speed { get; set; }
        public double Power { get; set; }
    }
}
