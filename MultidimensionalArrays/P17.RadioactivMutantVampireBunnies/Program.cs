using System;
using System.Collections.Generic;
using System.Linq;

namespace P17.RadioactivMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] array = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            Queue<char> moves = new Queue<char>(Console.ReadLine().ToCharArray());

            int playerRow = -1;
            int playerCol = -1;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }



            while (true)
            {
                string direction = moves.Dequeue().ToString();
                bool escaped = false;
                matrix[playerRow, playerCol] = '.';

                if (direction == "U")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        escaped = true;
                    }
                }
                else if (direction == "D")
                {
                    if (playerRow + 1 < matrix.GetLength(0))
                    {
                        playerRow++;
                    }
                    else
                    {
                        escaped = true;
                    }
                }
                else if (direction == "R")
                {
                    if (playerCol + 1 < matrix.GetLength(1))
                    {
                        playerCol++;
                    }
                    else
                    {
                        escaped = true;
                    }
                }
                else if (direction == "L")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        escaped = true;
                    }
                }

                Queue<int> bunnyCoordinates = new Queue<int>();

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (matrix[r, c] == 'B')
                        {
                            bunnyCoordinates.Enqueue(r);
                            bunnyCoordinates.Enqueue(c);
                        }
                    }
                }

                while (bunnyCoordinates.Count > 0)
                {
                    int r = bunnyCoordinates.Dequeue();
                    int c = bunnyCoordinates.Dequeue();

                    if (r - 1 >= 0 && matrix[r - 1, c] != 'B')
                    {
                        matrix[r - 1, c] = 'B';
                    }

                    if (r + 1 < matrix.GetLength(0) && matrix[r + 1, c] != 'B')
                    {
                        matrix[r + 1, c] = 'B';
                    }

                    if (c + 1 < matrix.GetLength(1) && matrix[r, c + 1] != 'B')
                    {
                        matrix[r, c + 1] = 'B';
                    }

                    if (c - 1 >= 0 && matrix[r, c - 1] != 'B')
                    {
                        matrix[r, c - 1] = 'B';
                    }
                }

                if (escaped)
                {
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            Console.Write(matrix[r,c]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
                else if (matrix[playerRow,playerCol] == 'B')
                {
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            Console.Write(matrix[r, c]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }

                matrix[playerRow, playerCol] = 'P';
            }

        }
    }
}
