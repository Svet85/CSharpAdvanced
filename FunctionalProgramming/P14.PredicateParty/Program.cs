using System;
using System.Collections.Generic;
using System.Linq;

namespace P14.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            Predicate<string> predicate = x => x.Contains("a");

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string filter = cmd[1];

                if (action == "Remove")
                {
                    string param = cmd[2];

                    if (filter == "StartsWith")
                    {
                        predicate = x => x.StartsWith(param);
                    }
                    else if (filter == "EndsWith")
                    {
                        predicate = x => x.EndsWith(param);
                    }
                    else if (filter == "Length")
                    {
                        int len = int.Parse(param);
                        predicate = x => x.Length == len;
                    }

                    people.RemoveAll(predicate);
                }
                else if (action == "Double")
                {
                    string param = cmd[2];
                    var newCollection = new List<string>();

                    if (filter == "StartsWith")
                    {
                        predicate = x => x.StartsWith(param);
                    }
                    else if (filter == "EndsWith")
                    {
                        predicate = x => x.EndsWith(param);
                    }
                    else if (filter == "Length")
                    {
                        int len = int.Parse(cmd[2]);
                        predicate = x => x.Length == len;
                    }

                    foreach (var person in people)
                    {
                        if (predicate(person))
                        {
                            newCollection.Add(person);
                            newCollection.Add(person);
                        }
                        else
                        {
                            newCollection.Add(person);
                        }
                    }

                    people = newCollection.ToList();
                }

                input = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}
