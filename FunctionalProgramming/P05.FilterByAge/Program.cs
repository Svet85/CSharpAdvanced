using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                people[name] = age;
            }

            string condition = Console.ReadLine();
            int ageBorder = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> filter = FilterPerson(condition, ageBorder);
            Action<KeyValuePair<string, int>> print = PrintPerson(format);

            foreach (var person in people.Where(x => filter(x.Value)))
            {
                print(person);
            }
        }

        public static Action<KeyValuePair<string, int>> PrintPerson(string format)
        {


            if (format == "name")
            {
                return x => Console.WriteLine($"{x.Key}"); ;
            }
            else if (format == "age")
            {
                return x => Console.WriteLine($"{x.Value}");
            }
            else if (format == "name age")
            {
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
            else
            {
                return x => Console.WriteLine("ERROR");
            }
        }

        public static Func<int, bool> FilterPerson(string condition, int ageBorde)
        {
            if (condition == "older")
            {
                return x => x >= ageBorde;
            }
            else if (condition == "younger")
            {
                return x => x < ageBorde;
            }
            else
            {
                return null;
            }
        }
    }
}

