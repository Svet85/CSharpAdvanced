namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = line.Count(char.IsLetter);
                int marksCount = line.Count(char.IsPunctuation);
                lines[i] = $"Line {i + 1}: {line} ({lettersCount})({marksCount})";
            }
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
            //File.WriteAllLines(outputFilePath, lines);
        }
    }
}
