using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if (ski == null || Count + 1 > Capacity)
            {
                return;
            }

            this.data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = null;
            foreach (var item in this.data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    ski = item;
                    break;
                }
            }

            return this.data.Remove(ski);
        }

        public Ski GetNewestSki()
        {
            Ski ski = null;
            int year = 0;
            foreach (var item in this.data)
            {
                if (item.Year > year)
                {
                    ski = item;
                    year = item.Year;
                }
            }

            return ski;

        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = null;
            foreach (var item in this.data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    ski = item;
                    break;
                }
            }

            return ski;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The skis stored in {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.data)}");

            return sb.ToString();
        }
    }
}
