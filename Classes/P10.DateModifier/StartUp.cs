using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date_1 = Console.ReadLine();
            string date_2 = Console.ReadLine();

            int diff = Datemodifier.NumberOfDaysBetweenDates(date_1, date_2);

            Console.WriteLine(diff);
        }
    }
}
