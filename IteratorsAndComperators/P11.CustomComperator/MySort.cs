using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CustomComperator
{
    public class MySort : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
            {
                return x.CompareTo(y);
            }

            if (x % 2 != 0)
            {
                return 1;
            }
            
            return -1;
        }
    }
}
