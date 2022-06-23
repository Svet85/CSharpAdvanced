using System;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int c = 0; c < size; c++)
                {
                    armory[r, c] = array[c];
                }
            }
            int goldSpent = 0;

            int[] officer = FindOfficer(armory, size);
            int officerRow = officer[0];
            int officerCol = officer[1];


            while (true)
            {
                string cmd = Console.ReadLine();
                
                armory[officerRow, officerCol] = '-';

                if (cmd == "up")
                {
                    if (officerRow == 0)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    officerRow--;

                    if (char.IsDigit(armory[officerRow,officerCol]))
                    {
                        goldSpent += armory[officerRow, officerCol] -'0';
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        armory[officerRow, officerCol] = '-';
                        int[] otherMirror = OtherMirrorCoordinates(armory,size);
                        officerRow = otherMirror[0];
                        officerCol = otherMirror[1];
                    }

                }
                else if (cmd == "down")
                {
                    if (officerRow == size - 1)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    officerRow++;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        goldSpent += armory[officerRow, officerCol] - '0';
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        armory[officerRow, officerCol] = '-';
                        int[] otherMirror = OtherMirrorCoordinates(armory, size);
                        officerRow = otherMirror[0];
                        officerCol = otherMirror[1];
                    }
                }
                else if (cmd == "left")
                {
                    if (officerCol == 0)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    officerCol--;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        goldSpent += armory[officerRow, officerCol] - '0';
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        armory[officerRow, officerCol] = '-';
                        int[] otherMirror = OtherMirrorCoordinates(armory, size);
                        officerRow = otherMirror[0];
                        officerCol = otherMirror[1];
                    }
                }
                else if (cmd == "right")
                {
                    if (officerCol == size - 1)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    officerCol++;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        goldSpent += armory[officerRow, officerCol] - '0';
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        armory[officerRow, officerCol] = '-';
                        int[] otherMirror = OtherMirrorCoordinates(armory, size);
                        officerRow = otherMirror[0];
                        officerCol = otherMirror[1];
                    }
                }

                armory[officerRow, officerCol] = 'A';
                
                if (goldSpent >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }
            }

            Console.WriteLine($"The king paid {goldSpent} gold coins.");
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(armory[r, c]);
                }
                Console.WriteLine();
            }

        }

        public static int[] OtherMirrorCoordinates(char[,] armory, int size)
        {
            int[] array = new int[2];
            bool flag = false;

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (armory[i, k] == 'M')
                    {
                        array[0] = i;
                        array[1] = k;
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

        public static int[] FindOfficer(char[,] armory, int size)
        {
            int[] array = new int[2];
            bool flag = false;

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (armory[i, k] == 'A')
                    {
                        array[0] = i;
                        array[1] = k;
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
