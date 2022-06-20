using System;
using System.Linq;

namespace Truffle_Hunter
{
    class Program
    {

        static void Main(string[] args)
        {
            int dimeansions = int.Parse(Console.ReadLine());
            char[,] field = new char[dimeansions, dimeansions];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] array = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = array[col];
                }
            }

            int blackTruff = 0;
            int summerTruff = 0;
            int whiteTruff = 0;
            int boarEatenTruff = 0;

            string input = Console.ReadLine();
            while (input != "Stop the hunt")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];

                if (action == "Collect")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);

                    if (field[row, col] == 'B')
                    {
                        blackTruff++;
                        field[row, col] = '-';
                    }
                    else if (field[row, col] == 'S')
                    {
                        summerTruff++;
                        field[row, col] = '-';
                    }
                    else if (field[row, col] == 'W')
                    {
                        whiteTruff++;
                        field[row, col] = '-';
                    }

                }
                else if (action == "Wild_Boar")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    string direction = cmd[3];

                    boarEatenTruff += BoarFeeding(field, direction, row, col);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruff} black, {summerTruff} summer, and {whiteTruff} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEatenTruff} truffles.");
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static int BoarFeeding(char[,] field, string direction, int r, int c)
        {
            int eatenTruffs = 0;

            if (direction == "up")
            {
                for (int row = r; row >= 0; row -= 2)
                {
                    if (field[row,c] == 'B' || field[row, c] == 'W' || field[row, c] == 'S')
                    {
                        field[row, c] = '-';
                        eatenTruffs++;
                    }
                }
            }
            else if (direction == "down")
            {
                for (int row = r; row < field.GetLength(0); row += 2)
                {
                    if (field[row, c] == 'B' || field[row, c] == 'W' || field[row, c] == 'S')
                    {
                        field[row, c] = '-';
                        eatenTruffs++;
                    }
                }
            }
            else if (direction == "right")
            {
                for (int col = c; col < field.GetLength(1); col += 2)
                {
                    if (field[r, col] == 'B' || field[r, col] == 'W' || field[r, col] == 'S')
                    {
                        field[r, col] = '-';
                        eatenTruffs++;
                    }
                }
            }
            else if (direction == "left")
            {
                for (int col = c; col >= 0; col -= 2)
                {
                    if (field[r, col] == 'B' || field[r, col] == 'W' || field[r, col] == 'S')
                    {
                        field[r, col] = '-';
                        eatenTruffs++;
                    }
                }
            }

            return eatenTruffs;
        }
    }
}
