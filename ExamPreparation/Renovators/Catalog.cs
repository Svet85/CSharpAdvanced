using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (Count + 1 > this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = null;
            foreach (var reno in this.renovators)
            {
                if (reno.Name == name)
                {
                    renovator = reno;
                }
            }

            return this.renovators.Remove(renovator);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {

            int result = this.renovators.RemoveAll(r => r.Type == type);
            return result;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = null;
            foreach (var reno in this.renovators)
            {
                if (reno.Name == name)
                {
                    renovator = reno;
                    break;
                }
            }

            if (renovator != null)
            {
                renovator.Hired = true;
            }

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> toBePaid = this.renovators.Where(x => x.Days >= days).ToList();

            return toBePaid;
        }

        public string Report()
        {
            StringBuilder info = new StringBuilder();
            info.Append($"Renovators available for Project {this.Project}:{Environment.NewLine}{string.Join(Environment.NewLine, this.renovators.Where(r => r.Hired == false))}");

            return info.ToString();
        }
    }
}
