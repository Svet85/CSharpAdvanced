using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                result = (x.Year * -1).CompareTo((y.Year * -1));
            }

            return result;
        }
    }
}
