﻿using System;

namespace GenericBoxOfIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }

        }
    }
}
