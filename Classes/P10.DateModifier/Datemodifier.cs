using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Datemodifier
    {
        public static int NumberOfDaysBetweenDates(string date_1, string date_2)
        {
            DateTime d_1 = Convert.ToDateTime(date_1);
            DateTime d_2 = Convert.ToDateTime(date_2);
            var diff = (d_1 - d_2).Days;
            return Math.Abs(diff);
        }
    }
}
