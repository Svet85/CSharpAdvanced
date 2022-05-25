using System;
using System.Collections.Generic;

namespace P13.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string input = Console.ReadLine();

            foreach (var _ch in input)
            {
                if (!chars.ContainsKey(_ch))
                {
                    chars.Add(_ch, 0);
                }

                chars[_ch]++;
            }

            foreach (var _char in chars)
            {
                Console.WriteLine($"{_char.Key}: {_char.Value} time/s");
            }
        }
    }
}
