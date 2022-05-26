using System;
using System.Collections.Generic;
using System.Linq;

namespace P17.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] info = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];

                if (info[1] != "banned")
                {
                    if (!students.ContainsKey(name))
                    {
                        students.Add(name, new Dictionary<string, int>());
                    }

                    string language = info[1];
                    int points = int.Parse(info[2]);

                    if (!students[name].ContainsKey(language))
                    {
                        students[name].Add(language, 0);
                    }

                    if (students[name][language] < points)
                    {
                        students[name][language] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;

                }
                else
                {
                    if (students.ContainsKey(name))
                    {
                        students.Remove(name);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(c => c.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Values.Sum()}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
