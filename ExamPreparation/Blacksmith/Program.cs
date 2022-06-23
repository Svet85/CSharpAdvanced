using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                ["Gladius"] = 0,
                ["Shamshir"] = 0,
                ["Katana"] = 0,
                ["Sabre"] = 0,
                ["Broadsword"] = 0,
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                string swordType = Forging(currentSteel,currentCarbon);

                if (swordType == "invalid")
                {
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
                else
                {
                    swords[swordType]++;
                }
            }

            if (swords.Values.Sum() > 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            string leftSteel = steel.Count > 0 ? string.Join(", ", steel) : "none";
            string leftCarbon = carbon.Count > 0 ? string.Join(", ", carbon) : "none";
            Console.WriteLine($"Steel left: {leftSteel}");
            Console.WriteLine($"Carbon left: {leftCarbon}");

            foreach (var sword in swords.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }

        public static string Forging(int currentSteel, int currentCarbon)
        {
            int sum = currentCarbon + currentSteel;
            string sword = "";

            switch (sum)
            {
                case 70:
                    sword = "Gladius";
                    break;
                case 80:
                    sword = "Shamshir";
                    break;
                case 90:
                    sword = "Katana";
                    break;
                case 110:
                    sword = "Sabre";
                    break;
                case 150:
                    sword = "Broadsword";
                    break;
                default:
                    sword = "invalid";
                    break;
            }

            return sword;
        }
    }
}
