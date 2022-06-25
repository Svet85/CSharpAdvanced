using System;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            for (int r = 0; r < 8; r++)
            {

                char[] array = Console.ReadLine().ToCharArray();
                for (int c = 0; c < 8; c++)
                {
                    board[r, c] = array[c];
                }
            }

            int[] blackPawnCoordinates = FindBlack(board);
            int[] whitePawnCoordinates = FindWhite(board);
            int blackRow = blackPawnCoordinates[0];
            int blackCol = blackPawnCoordinates[1];
            int whiteRow = whitePawnCoordinates[0];
            int whiteCol = whitePawnCoordinates[1];

            while (true)
            {
                board[whiteRow, whiteCol] = '-';
                if (whiteRow == 0)
                {
                    string coordinates = $"{ToALetter(whiteCol)}8";
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    break;
                }
                else if ((whiteCol + 1 < 8 && board[whiteRow - 1,whiteCol + 1] == 'b') || (whiteCol - 1 >=0 && board[whiteRow - 1, whiteCol - 1] == 'b'))
                {
                    board[blackRow, blackCol] = 'w';
                    string coordinates = $"{ToALetter(blackCol)}{ 8 - blackRow}";
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    break;
                }

                whiteRow--;
                board[whiteRow, whiteCol] = 'w';

                board[blackRow, blackCol] = '-';
                if (blackRow == 7)
                {
                    string coordinates = $"{ToALetter(blackCol)}1";
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    break;
                }
                else if ( (blackCol + 1 < 8  && board[blackRow + 1, blackCol + 1] == 'w') || ( blackCol - 1 >= 0 && board[blackRow + 1, blackCol - 1] == 'w'))
                {
                    board[whiteRow, whiteCol] = 'b';
                    string coordinates = $"{ToALetter(whiteCol)}{ 8 - whiteRow}";
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    break;
                }

                blackRow++;
                board[blackRow, blackCol] = 'b';
            }
        }

        public static string ToALetter(int col)
        {
            string letter = "";

            switch (col)
            {
                case 0:
                    letter = "a";
                    break;
                case 1:
                    letter = "b";
                    break;
                case 2:
                    letter = "c";
                    break;
                case 3:
                    letter = "d";
                    break;
                case 4:
                    letter = "e";
                    break;
                case 5:
                    letter = "f";
                    break;
                case 6:
                    letter = "g";
                    break;
                case 7:
                    letter = "h";
                    break;
                default:
                    break;
            }

            return letter;
        }

        public static int[] FindWhite(char[,] board)
        {
            int[] array = new int[2];
            bool flag = false;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (board[r,c] == 'w')
                    {
                        array[0] = r;
                        array[1] = c;
                        flag = true;
                        break;
                    }

                }


                if (flag)
                {
                    break;
                }
            }

            return array;
        }

        public static int[] FindBlack(char[,] board)
        {
            int[] array = new int[2];
            bool flag = false;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (board[r, c] == 'b')
                    {
                        array[0] = r;
                        array[1] = c;
                        flag = true;
                        break;
                    }

                }


                if (flag)
                {
                    break;
                }
            }

            return array;
        }
    }
}
