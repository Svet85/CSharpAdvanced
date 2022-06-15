using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            var stack = new Stack<int>(elements);

            string input = Console.ReadLine();
            try
            {
                while (input != "END")
                {
                    string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string action = info[0];

                    if (action == "Pop")
                    {
                        stack.Pop();
                    }
                    else if (action == "Push")
                    {
                        int element = int.Parse(info[1]);
                        stack.Push(element);
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
