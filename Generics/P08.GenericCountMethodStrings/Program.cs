using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> elements = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                elements.Add(box);
            }
            string comparingElement = Console.ReadLine();
            int count = NumberOfGreaterElements(elements, comparingElement);
            Console.WriteLine(count);
        }

        public static int NumberOfGreaterElements<T>(List<Box<T>> elements, T comparingElement)
            where T : IComparable
        {
            int result = 0;
            foreach (var item in elements)
            {
                if (item.CompareTo(comparingElement) > 0)
                {
                    result++;
                }
                
            }

            return result;
        }
    }
}
