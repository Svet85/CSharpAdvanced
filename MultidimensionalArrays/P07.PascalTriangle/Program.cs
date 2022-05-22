using System;

namespace P07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] jArray = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                jArray[row] = new long[row + 1];

                for (int col = 0; col < jArray[row].Length; col++)
                {
                    if (col == 0 || col == jArray[row].Length - 1)
                    {
                        jArray[row][col] = 1;
                    }
                    else
                    {
                        jArray[row][col] = jArray[row - 1][col - 1] + jArray[row - 1][col];
                    }
                }
            }

            foreach (var array in jArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }

        }
    }
}
