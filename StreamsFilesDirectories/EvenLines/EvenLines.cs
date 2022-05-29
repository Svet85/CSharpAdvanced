namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] array = new char[] { '-', ',', '.', '!', '?' };
            StringBuilder lines = new StringBuilder();

            int counter = 0;
            using (var reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        var reversedLine = ReversedLine(line);
                        lines.AppendLine(reversedLine);
                    }

                    counter++;
                }
            }

            ReplacingChars(array, lines);

            return lines.ToString();
        }

        public static string ReversedLine(string line)
        {

            StringBuilder text = new StringBuilder();
            string[] array = line.Split().Reverse().ToArray();

            foreach (var item in array)
            {
                text.Append(item + " ");
            }

            string reversed = text.ToString().TrimEnd();
            return reversed;
        }

        public static void ReplacingChars(char[] array, StringBuilder lines)
        {
            foreach (var _char in array)
            {
                lines.Replace(_char, '@');
            }
        }
    }
}
