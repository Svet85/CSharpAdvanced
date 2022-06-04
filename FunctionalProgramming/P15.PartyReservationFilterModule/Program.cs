using System;
using System.Collections.Generic;
using System.Linq;

namespace P15.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] cmd = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];

                if (action == "Add filter")
                {
                    filters.Add(cmd[1] + ";" + cmd[2]);
                }
                else if (action == "Remove filter")
                {
                    filters.RemoveAll(x => x == cmd[1] + ";" + cmd[2]);
                }

                input = Console.ReadLine();
            }

            Predicate<string> predicate = x => x == "a";

            foreach (var filter in filters)
            {
                string[] cmd = filter.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string param = cmd[1];

                if (action == "Starts with")
                {
                    predicate = x => x.StartsWith(param);
                }
                else if (action == "Ends with")
                {
                    predicate = x => x.EndsWith(param);
                }
                else if (action == "Length")
                {
                    int n = int.Parse(param);
                    predicate = x => x.Length == n;
                }
                else if (action == "Contains")
                {
                    predicate = x => x.Contains(param);
                }

                if (people.Count > 0)
                {
                    people.RemoveAll(predicate);
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
