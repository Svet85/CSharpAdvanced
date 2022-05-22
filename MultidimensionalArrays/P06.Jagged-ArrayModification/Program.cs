using System;
using System.Linq;

namespace P06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jArray = new int[rows][];

            for (int r = 0; r < rows; r++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jArray[r] = new int[nums.Length];

                for (int c = 0; c < nums.Length; c++)
                {
                    jArray[r][c] = nums[c];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmd = input.Split();
                string action = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (!(row >= 0 && row < jArray.Length) || !(col >= 0 && col < jArray[row].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (action == "Add")
                {
                    jArray[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    jArray[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            foreach (var array in jArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
