using System;
using System.Linq;

namespace P08.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int r = 0; r < n; r++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            int primaryD = 0;
            int secondaryD = 0;
            
            for (int i = 0; i < n; i++)
            {
                primaryD += matrix[i, i];
                secondaryD += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            Console.WriteLine(Math.Abs(primaryD - secondaryD));
        }
    }
}
