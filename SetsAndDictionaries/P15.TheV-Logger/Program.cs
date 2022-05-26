using System;
using System.Collections.Generic;
using System.Linq;

namespace P15.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<SortedSet<string>>> vloggers = new Dictionary<string, List<SortedSet<string>>>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] info = input.Split();
                string vloggerName = info[0];
                string action = info[1];

                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new List<SortedSet<string>>());
                        vloggers[vloggerName].Add(new SortedSet<string>());
                        vloggers[vloggerName].Add(new SortedSet<string>());
                    }
                }
                else if (action == "followed")
                {
                    string followed = info[2];
                    
                    if ((vloggerName != followed) && (vloggers.ContainsKey(followed)) && (vloggers.ContainsKey(vloggerName)) && (!vloggers[followed][0].Contains(vloggerName)))
                    {
                        vloggers[vloggerName][1].Add(followed);
                        vloggers[followed][0].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }

            vloggers = vloggers.OrderByDescending(c => c.Value[0].Count).ThenBy(c => c.Value[1].Count).ToDictionary(c => c.Key, c => c.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 1;
            foreach (var vlogger in vloggers)
            {
                if (counter == 1 && vlogger.Value[0].Count > 0)
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");
                    
                    foreach (var follоwer in vlogger.Value[0])
                    {
                        Console.WriteLine($"*  {follоwer}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");
                }

                counter++;
            }
        }
    }
}
