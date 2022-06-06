using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Trainer
    {
        public Trainer(string name, int badges = 0)
        {
            Name = name;
            Badges = badges;
            Collection = new List<Pokemon>();
        }

        public string Name { get; set; }
        public List<Pokemon> Collection { get; set; }
        public int Badges { get; set; }
    }
}
