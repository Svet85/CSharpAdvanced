using System;

namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int c = 0; c < size; c++)
                {
                    wall[r, c] = array[c];
                }
            }

            int[] vankoPosition = FindVanko(wall);
            int vankoRow = vankoPosition[0];
            int vankoCol = vankoPosition[1];
            int hitRods = 0;
            bool isElectrocuted = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                wall[vankoRow, vankoCol] = '*';

                if (command == "up" && vankoRow - 1 >= 0)
                {
                    vankoRow--;
                    if (wall[vankoRow,vankoCol] == 'R')
                    {
                        vankoRow++;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[vankoRow, vankoCol] == 'C')
                    {
                        wall[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[vankoRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "down" && vankoRow + 1 < size)
                {
                    vankoRow++;
                    if (wall[vankoRow, vankoCol] == 'R')
                    {
                        vankoRow--;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[vankoRow, vankoCol] == 'C')
                    {
                        wall[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[vankoRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }

                }
                else if (command == "right" && vankoCol + 1 < size)
                {
                    vankoCol++;
                    if (wall[vankoRow, vankoCol] == 'R')
                    {
                        vankoCol--;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[vankoRow, vankoCol] == 'C')
                    {
                        wall[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[vankoRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "left" && vankoCol - 1 >= 0)
                {
                    vankoCol--;
                    if (wall[vankoRow, vankoCol] == 'R')
                    {
                        vankoCol++;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[vankoRow, vankoCol] == 'C')
                    {
                        wall[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[vankoRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }

                wall[vankoRow, vankoCol] = 'V';
                command = Console.ReadLine();
            }

            int holes = 0;
            foreach (var _char in wall)
            {
                if (_char == 'E' || _char == '*' || _char == 'V')
                {
                    holes++;
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {hitRods} rod(s).");
            }

            for (int r = 0; r < wall.GetLength(0); r++)
            {
                for (int c = 0; c < wall.GetLength(1); c++)
                {
                    Console.Write(wall[r,c]);
                }

                Console.WriteLine();
            }
        }

        public static int[] FindVanko(char[,] wall)
        {
            int[] array = new int[2];
            bool found = false;

            for (int r = 0; r < wall.GetLength(0); r++)
            {
                for (int c = 0; c < wall.GetLength(1); c++)
                {
                    if (wall[r, c] == 'V')
                    {
                        array[0] = r;
                        array[1] = c;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return array;
        }
    }
}
