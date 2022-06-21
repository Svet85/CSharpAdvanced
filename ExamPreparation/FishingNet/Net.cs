using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;
        public Net(string material, int capacity)
        {
            this.fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public IReadOnlyList<Fish> Fish => fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Fish.Count;


        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count == Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fishToRemove = this.fish.FirstOrDefault(x => x.Weight == weight);
            return this.fish.Remove(fishToRemove);
        }

        public Fish GetFish(string fishType)
        {
            return this.fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            var biggestFish = this.fish.OrderByDescending(x => x.Length).ElementAt(0);
            return biggestFish;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Into the {this.Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                text.AppendLine(fish.ToString());
            }

            return text.ToString().TrimEnd();
        }
    }
}
