using System;
using System.Collections.Generic;
using System.Linq;

namespace P14.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = info[0];
                string[] clothes = info[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }


                for (int k = 0; k < clothes.Length; k++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[k]))
                    {
                        wardrobe[color].Add(clothes[k], 0);
                    }

                    wardrobe[color][clothes[k]]++;
                }
            }

            string[] cmd = Console.ReadLine().Split();

            foreach (var drawer in wardrobe)
            {
                Console.WriteLine($"{drawer.Key} clothes:");

                foreach (var piece in drawer.Value)
                {
                    if (drawer.Key == cmd[0] && piece.Key == cmd[1])
                    {
                        Console.WriteLine($"* {piece.Key} - {piece.Value} (found!)");
                    }
                    else
                    {
                    Console.WriteLine($"* {piece.Key} - {piece.Value}");
                    }
                }
            }
        }
    }
}
