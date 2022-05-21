using System;

namespace P04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int r = 0; r < n; r++)
            {
                char[] array = Console.ReadLine().ToCharArray();

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c] == symbol)
                    {
                        Console.WriteLine($"({r}, {c})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
