using System;
using System.Linq;

namespace P09._2X2SquaresInmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] array = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    bool flag = matrix[i, k] == matrix[i + 1, k] && matrix[i, k] == matrix[i, k + 1] && matrix[i, k] == matrix[i + 1, k + 1];

                    if (flag)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
