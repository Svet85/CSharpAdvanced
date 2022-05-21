using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = numbers[c];
                }
            }

            int n = 2;
            int sum = 0;
            int row = -1;
            int col = -1;

            for (int i = 0; i <= matrix.GetLength(0) - n; i++)
            {
                for (int k = 0; k <= matrix.GetLength(1) - n; k++)
                {
                    int tempSum = 0;
                    
                    for (int g = i; g < i + n; g++)
                    {
                        for (int f = k; f < k + n; f++)
                        {
                            tempSum += matrix[g, f];
                        }
                    }

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        row = i;
                        col = k;
                    }
                }
            }

            for (int r = row; r < row + n; r++)
            {
                for (int c = col; c < col + n; c++)
                {
                    Console.Write($"{matrix[r,c]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(sum);
        }
    }
}
