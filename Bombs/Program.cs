using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());
            int[,] matrix = new int[side, side];

            for (int row = 0; row < side; row++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split();
            // if size is bigger than zero

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] bomb = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = bomb[0];
                int col = bomb[1];

                if (matrix[row, col] > 0)
                {
                    int power = matrix[row, col];
                    int startRow = 0;
                    int startCol = 0;
                    int endRow = matrix.GetLength(0) - 1;
                    int endCol = matrix.GetLength(1) - 1;

                    if (row - 1 > 0)
                    {
                        startRow = row - 1;
                    }

                    if (row + 1 < matrix.GetLength(0) - 1)
                    {
                        endRow = row + 1;
                    }

                    if (col - 1 > 0)
                    {
                        startCol = col - 1;
                    }

                    if (col + 1 < matrix.GetLength(1) - 1)
                    {
                        endCol = col + 1;
                    }

                    for (int k = startRow; k <= endRow; k++)
                    {
                        for (int x = startCol; x <= endCol; x++)
                        {
                            if (matrix[k,x] > 0)
                            {
                                matrix[k, x] -= power;
                            }
                        }
                    }
                }
            }

            int counter = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    counter++;
                    sum += item;
                }
            }

            Console.WriteLine($"Alive cells; {counter}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < side; row++)
            {
                for (int col = 0; col < side; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
