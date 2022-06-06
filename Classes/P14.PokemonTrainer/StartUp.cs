using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {


        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameTrainer = info[0];
                string pokemonName = info[1];
                string pokemonEle = info[2];
                int health = int.Parse(info[3]);
                if (!trainers.Exists(x => x.Name == nameTrainer))
                {
                    var trainer = new Trainer(nameTrainer);
                    trainers.Add(trainer);
                }
                var existingTrainer = trainers.Find(x => x.Name == nameTrainer);
                var pokemon = new Pokemon(pokemonName, pokemonEle, health);
                existingTrainer.Collection.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Collection.Any(x => x.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        bool dead = false;
                        foreach (var pokemon in trainer.Collection)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                dead = true;
                            }
                        }

                        if (dead)
                        {
                            foreach (var trainer1 in trainers)
                            {
                                trainer.Collection.RemoveAll(x => x.Health <= 0);
                            }
                        }

                    }
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Collection.Count}");
            }
        }
    }
}
