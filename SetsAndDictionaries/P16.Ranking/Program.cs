using System;
using System.Collections.Generic;
using System.Linq;

namespace P16.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> exams = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] info = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = info[0];
                string pass = info[1];

                if (!exams.ContainsKey(contest))
                {
                    exams.Add(contest, "");
                }

                exams[contest] = pass;

                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] info = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = info[0];
                string pass = info[1];
                string name = info[2];
                int points = int.Parse(info[3]);

                if (exams.ContainsKey(contest) && exams[contest] == pass)
                {
                    if (!students.ContainsKey(name))
                    {
                        students.Add(name, new Dictionary<string, int>());
                    }

                    if (!students[name].ContainsKey(contest))
                    {
                        students[name].Add(contest, points);
                    }
                    else
                    {
                        if (students[name][contest] < points)
                        {
                            students[name][contest] = points;
                        }
                    }
                }

                input = Console.ReadLine();
            }


            foreach (var student in students.OrderByDescending(x => x.Value.Values.Sum()).Take(1))
            {
                Console.WriteLine($"Best candidate is {student.Key} with total {student.Value.Values.Sum()} points.");
            }

            Console.WriteLine("Ranking:");

            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var exam in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {exam.Key} -> {exam.Value}");
                }
            }
        }
    }
}
