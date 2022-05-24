using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                double grade = double.Parse(info[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                }

                grades[name].Add(grade);
            }

            foreach (var student in grades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("f2")) )} (avg: {student.Value.Average():0.00})");
            }

        }
    }
}
