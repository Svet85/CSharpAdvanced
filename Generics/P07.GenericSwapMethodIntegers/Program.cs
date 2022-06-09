using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index_1 = indexes[0];
            int index_2 = indexes[1];
            Swap(boxes, index_1, index_2);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        public static void Swap<T>(List<Box<T>> boxes, int index_1, int index_2)
        {
            var box_1 = boxes[index_1];
            boxes[index_1] = boxes[index_2];
            boxes[index_2] = box_1;
        }
    }
}
