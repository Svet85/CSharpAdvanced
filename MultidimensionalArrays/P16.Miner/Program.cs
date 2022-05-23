using System;
using System.Collections.Generic;

namespace P16.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            Queue<string> directions = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            for (int row = 0; row < n; row++)
            {
                char[] array = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = array[col];
                }
            }

            int coals = 0;
            int minerRow = 0;
            int minerCol = 0;

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (field[i, k] == 'c')
                    {
                        coals++;
                    }

                    if (field[i, k] == 's')
                    {
                        minerRow = i;
                        minerCol = k;
                    }
                }
            }

            while (directions.Count > 0)
            {
                string direction = directions.Dequeue();
                field[minerRow, minerCol] = '*';

                if (direction == "up")
                {
                    if (Inside(minerRow - 1, minerCol, n))
                    {
                        minerRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (Inside(minerRow + 1, minerCol, n))
                    {
                        minerRow++;
                    }
                }
                else if (direction == "right")
                {
                    if (Inside(minerRow, minerCol + 1, n))
                    {
                        minerCol++;
                    }
                }
                else if (direction == "left")
                {
                    if (Inside(minerRow, minerCol - 1, n))
                    {
                        minerCol--;
                    }
                }

                if (field[minerRow,minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    Environment.Exit(0);
                }

                if (field[minerRow,minerCol] == 'c')
                {
                    coals--;
                    field[minerRow, minerCol] = '*';

                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        Environment.Exit(0);
                    }
                }

                field[minerRow, minerCol] = 's';
            }

            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
        }

        public static bool Inside(int row, int col, int size)
        {
            if ((row >= 0 && row < size) && (col >= 0 && col < size))
            {
                return true;
            }

            return false;
        }
    }
}
