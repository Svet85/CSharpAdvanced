using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int jarrayRows = int.Parse(Console.ReadLine());
            char[][] field = new char[jarrayRows][];

            for (int r = 0; r < field.Length; r++)
            {
                field[r] = Console.ReadLine().ToCharArray();
            }

            int[] playerPosition = FindPlayer(field);
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            while (true)
            {
                string[] cmd = Console.ReadLine().Split();
                string direction = cmd[0];
                int orcRow = int.Parse(cmd[1]);
                int orcCol = int.Parse(cmd[2]);

                field[orcRow][orcCol] = 'O';
                field[playerRow][playerCol] = '-';
                if (direction == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        armor--;
                    }
                    else
                    {
                        playerRow--;
                        armor--;
                    }
                }
                else if (direction == "down")
                {
                    if (playerRow + 1 > field.Length - 1)
                    {
                        armor--;
                    }
                    else
                    {
                        playerRow++;
                        armor--;
                    }
                }
                else if (direction == "right")
                {
                    if (playerCol + 1 > field[playerRow].Length - 1)
                    {
                        armor--;
                    }
                    else
                    {
                        playerCol++;
                        armor--;
                    }
                }
                else if (direction == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        armor--;
                    }
                    else
                    {
                        playerCol--;
                        armor--;
                    }
                }


                if (field[playerRow][playerCol] == 'M')
                {
                    field[playerRow][playerCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (field[playerRow][playerCol] == 'O')
                {
                    armor -= 2;
                }

                if (armor <= 0)
                {
                    field[playerRow][playerCol] = 'X';
                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol}.");
                    break;
                }

                field[playerRow][playerCol] = 'A';
            }

            for (int r = 0; r < field.Length; r++)
            {
                Console.WriteLine(string.Join("", field[r]));
            }
        }

        public static int[] FindPlayer(char[][] field)
        {
            int[] coord = new int[2];
            bool found = false;
            
            for (int r = 0; r < field.Length; r++)
            {
                for (int c = 0; c < field[r].Length; c++)
                {
                    if (field[r][c] == 'A')
                    {
                        coord[0] = r;
                        coord[1] = c;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return coord;
        }
    }
}
