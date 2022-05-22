using System;
using System.Linq;

namespace P10.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            long sum = long.MinValue;
            int row = 0;
            int col = 0;

            for (int r = 0; r <= matrix.GetLength(0) - 3; r++)
            {
                for (int c = 0; c <= matrix.GetLength(1) - 3; c++)
                {
                    long tempSum = 0;

                    for (int i = r; i < r + 3; i++)
                    {
                        for (int k = c; k < c + 3; k++)
                        {
                            tempSum += matrix[i, k];
                        }
                    }

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        row = r;
                        col = c;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int i = row; i < row + 3; i++)
            {
                for (int k = col; k < col + 3; k++)
                {
                    Console.Write($"{matrix[i, k]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
