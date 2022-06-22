using System;
using System.Collections.Generic;

namespace BeaverAtWork
{
    class Program
    {
        public static int branches = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];

            for (int row = 0; row < n; row++)
            {

                char[] array = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    pond[row, col] = array[col];
                }
            }

            int[] beaverCoordinates = FindBeaver(pond);
            int beaverRow = beaverCoordinates[0];
            int beaverCol = beaverCoordinates[1];
            branches = FindBranches(pond);
            List<char> collectedBranches = new List<char>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = MovingBeaverUp(beaverRow, beaverCol, pond, collectedBranches);
                    }
                }
                else if (input == "down")
                {
                    if (beaverRow == pond.GetLength(0) - 1)
                    {
                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = MovingBeaverDown(beaverRow, beaverCol, pond, collectedBranches);
                    }
                }
                else if (input == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = MovingBeaverLeft(beaverRow, beaverCol, pond, collectedBranches);
                    }
                }
                else if (input == "right")
                {
                    if (beaverCol == pond.GetLength(1) - 1)
                    {
                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = MovingBeaverRight(beaverRow, beaverCol, pond, collectedBranches);
                    }
                }

                pond[beaverRow, beaverCol] = 'B';

                if (branches == 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (branches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branches} branches left.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

        public static int MovingBeaverRight(int beaverRow, int beaverCol, char[,] pond, List<char> collectedBranches)
        {
            beaverCol++;

            if (pond[beaverRow, beaverCol] == 'F')
            {
                pond[beaverRow, beaverCol] = '-';

                if (beaverCol == pond.GetLength(1) - 1)
                {
                    beaverCol = 0;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
                else
                {
                    beaverCol = pond.GetLength(1) - 1;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
            }
            else
            {
                BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
            }

            return beaverCol;
        }

        public static int MovingBeaverLeft(int beaverRow, int beaverCol, char[,] pond, List<char> collectedBranches)
        {
            beaverCol--;

            if (pond[beaverRow, beaverCol] == 'F')
            {
                pond[beaverRow, beaverCol] = '-';

                if (beaverCol == 0)
                {
                    beaverCol = pond.GetLength(1) - 1;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
                else
                {
                    beaverCol = 0;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
            }
            else
            {
                BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
            }

            return beaverCol;
        }

        public static int MovingBeaverDown(int beaverRow, int beaverCol, char[,] pond, List<char> collectedBranches)
        {
            beaverRow++;

            if (pond[beaverRow, beaverCol] == 'F')
            {
                pond[beaverRow, beaverCol] = '-';

                if (beaverRow == pond.GetLength(0) - 1)
                {
                    beaverRow = 0;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
                else
                {
                    beaverRow = pond.GetLength(0) - 1;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
            }
            else
            {
                BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
            }

            return beaverRow;
        }

        public static int MovingBeaverUp(int beaverRow, int beaverCol, char[,] pond, List<char> collectedBranches)
        {
            beaverRow--;

            if (pond[beaverRow, beaverCol] == 'F')
            {
                pond[beaverRow, beaverCol] = '-';

                if (beaverRow == 0)
                {
                    beaverRow = pond.GetLength(0) - 1;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
                else
                {
                    beaverRow = 0;
                    BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
                }
            }
            else
            {
                BranchCheck(beaverRow, beaverCol, pond, collectedBranches);
            }

            return beaverRow;
        }

        public static void BranchCheck(int beaverRow, int beaverCol, char[,] pond, List<char> collectedBranches)
        {
            if (char.IsLower(pond[beaverRow, beaverCol]))
            {
                collectedBranches.Add(pond[beaverRow, beaverCol]);
                branches--;
            }
        }

        public static int FindBranches(char[,] pond)
        {
            int count = 0;

            for (int r = 0; r < pond.GetLength(0); r++)
            {
                for (int c = 0; c < pond.GetLength(1); c++)
                {
                    if (char.IsLower(pond[r, c]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int[] FindBeaver(char[,] pond)
        {
            int[] array = new int[2];
            bool flag = false;

            for (int r = 0; r < pond.GetLength(0); r++)
            {
                for (int c = 0; c < pond.GetLength(1); c++)
                {
                    if (pond[r, c] == 'B')
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
