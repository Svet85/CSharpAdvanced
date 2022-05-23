using System;
using System.Linq;

namespace P13.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jArray = new int[rows][];

            for (int r = 0; r < jArray.Length; r++)
            {
                jArray[r] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int r = 0; r < jArray.Length - 1; r++)
            {
                if (jArray[r].Length == jArray[r + 1].Length)
                {
                    jArray[r] = jArray[r].Select(x => x * 2).ToArray();
                    jArray[r + 1] = jArray[r + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jArray[r] = jArray[r].Select(x => x / 2).ToArray();
                    jArray[r + 1] = jArray[r + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmd = input.Split();
                string action = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if ((row >= 0 && row < jArray.Length) && (col >= 0 && col < jArray[row].Length))
                {
                    if (action == "Add")
                    {
                        jArray[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jArray[row][col] -= value;
                    }
                }
                
                input = Console.ReadLine();
            }

            for (int r = 0; r < jArray.Length; r++)
            {
                Console.WriteLine(string.Join(" ", jArray[r]));
            }
        }
    }
}
