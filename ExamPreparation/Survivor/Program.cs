using System;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int r = 0; r < rows; r++)
            {
                beach[r] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            int playerTokens = 0;
            int opponentTokens = 0;

            string input = Console.ReadLine();
            while (input != "Gong")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];

                if (action == "Find")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);

                    if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                    {
                        if (beach[row][col] == 'T')
                        {
                            playerTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (action == "Opponent")
                {
                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    string direction = cmd[3];

                    if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                    {
                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row--;
                                if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                                {
                                    if (beach[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row++;
                                if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                                {
                                    if (beach[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                col++;
                                if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                                {
                                    if (beach[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                col--;
                                if ((row >= 0 && row < rows) && (col >= 0 && col < beach[row].Length))
                                {
                                    if (beach[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][col] = '-';
                                    }
                                }
                            }
                        }
                    }
                }
                
                input = Console.ReadLine();
            }

            for (int r = 0; r < beach.Length; r++)
            {
                Console.WriteLine(string.Join(" ", beach[r]));
            }

            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
