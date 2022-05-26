using System;
using System.Collections.Generic;
using System.Linq;

namespace P18.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> heroes = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] info = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = info[0];
                    string name = info[1];

                    if (!heroes.ContainsKey(name))
                    {
                        heroes.Add(name, side);
                    }

                }
                else
                {
                    string[] info = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0];
                    string side = info[1];

                    if (!heroes.ContainsKey(name))
                    {
                        heroes.Add(name, side);
                    }
                    else
                    {
                        heroes[name] = side;
                    }

                    Console.WriteLine($"{name} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            foreach (var hero in heroes)
            {
                if (!sides.ContainsKey(hero.Value))
                {
                    sides.Add(hero.Value, new List<string>());
                }

                sides[hero.Value].Add(hero.Key);
            }

            foreach (var side in sides.OrderByDescending(u => u.Value.Count).ThenBy(s => s.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value.OrderBy(u => u))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }

            }
        }
    }
}
