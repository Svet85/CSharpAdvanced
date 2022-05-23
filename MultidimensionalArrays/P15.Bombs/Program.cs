using System;
using System.Collections.Generic;
using System.Linq;

namespace P15.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            
            if (dimensions == 0)
            {
                Environment.Exit(0);
            }

            int[,] matrix = new int[dimensions,dimensions];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            Queue<int> coordinates = new Queue<int>(Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (coordinates.Count > 0)
            {
                int row = coordinates.Dequeue();
                int col = coordinates.Dequeue();

                if (matrix[row,col] > 0)
                {
                    int bombPower = matrix[row, col];

                    for (int r = row - 1; r <= row + 1 ; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if ((r >= 0 && r < matrix.GetLength(0)) && (c >= 0 && c < matrix.GetLength(1)) && matrix[r,c] > 0)
                            {
                                matrix[r, c] -= bombPower;
                            }
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write($"{matrix[i,k]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
