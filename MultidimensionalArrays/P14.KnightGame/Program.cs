using System;

namespace P14.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sides = int.Parse(Console.ReadLine());
            char[,] board = new char[sides, sides];

            for (int r = 0; r < sides; r++)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int c = 0; c < sides; c++)
                {
                    board[r, c] = array[c];
                }
            }

            int counter = 0;
            int attacks = 0;
            int row = -1;
            int col = -1;

            while (true)
            {
                for (int r = 0; r < sides; r++)
                {

                    for (int c = 0; c < sides; c++)
                    {
                        int maxAttacks = 0;

                        if (board[r, c] == 'K')
                        {
                            if (IsInside(sides, r + 2, c + 1) && board[r + 2, c + 1] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r + 2, c - 1) && board[r + 2, c - 1] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r + 1, c - 2) && board[r + 1, c - 2] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r + 1, c + 2) && board[r + 1, c + 2] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r - 1, c - 2) && board[r - 1, c - 2] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r - 1, c + 2) && board[r - 1, c + 2] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r - 2, c - 1) && board[r - 2, c - 1] == 'K')
                            {
                                maxAttacks++;
                            }

                            if (IsInside(sides, r - 2, c + 1) && board[r - 2, c + 1] == 'K')
                            {
                                maxAttacks++;
                            }
                        }

                        if (maxAttacks > attacks)
                        {
                            attacks = maxAttacks;
                            row = r;
                            col = c;
                        }
                    }
                }

                if (attacks == 0)
                {
                    break;
                }

                counter++;
                board[row, col] = '0';
                attacks = 0;

            }

            Console.WriteLine(counter);
        }

        public static bool IsInside(int sides, int r, int c)
        {
            bool inside = (r >= 0 && r < sides) && (c >= 0 && c < sides);

            return inside;
        }
    }
}
