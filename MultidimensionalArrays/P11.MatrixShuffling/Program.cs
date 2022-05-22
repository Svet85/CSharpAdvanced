using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmd = input.Split();

                if (cmd.Length != 5 || cmd[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);

                    if ((row1 >= 0 && row1 < matrix.GetLength(0)) && (row2 >= 0 && row2 < matrix.GetLength(0)) && (col1 >= 0 && col1 < matrix.GetLength(1)) && (col2 >= 0 && col2 < matrix.GetLength(1)))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                Console.Write($"{matrix[r,c]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }



                input = Console.ReadLine();
            }
        }
    }
}
