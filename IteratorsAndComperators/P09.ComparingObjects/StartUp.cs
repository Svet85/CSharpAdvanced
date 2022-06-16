using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] info = input.Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];

                people.Add(new Person(name, age, town));

                input = Console.ReadLine();
            }

            Person personToCompare = people[int.Parse(Console.ReadLine()) - 1];
            int equalPeople = 0;
            int differentPeople = 0;

            foreach (var item in people)
            {
                if (item.CompareTo(personToCompare) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    differentPeople++;
                }
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
            }

        }
    }
}
