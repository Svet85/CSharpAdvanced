using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (!(animal.Diet == "herbivore" || animal.Diet == "carnivore"))
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = Animals.RemoveAll(x => x.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsbyDiet = Animals.Where(x => x.Diet == diet).ToList();
            return animalsbyDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            var animalByWeight = Animals.FirstOrDefault(x => x.Weight == weight);
            return animalByWeight;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Count(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
