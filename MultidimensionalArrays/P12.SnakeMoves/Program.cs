using System;
using System.Linq;

namespace P12.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            string snake = Console.ReadLine();
            int counter = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r % 2 == 0)
                    {
                        matrix[r, c] = snake[counter];
                    }
                    else
                    {
                        matrix[r, matrix.GetLength(1) - 1 - c] = snake[counter];
                    }

                    counter++;

                    if (counter == snake.Length)
                    {
                        counter = 0;
                    }
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r,c]);
                }
                Console.WriteLine();
            }
        }
    }
}
