namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                using (var reader = new StreamReader(firstInputFilePath))
                {
                    using (var reader_2 = new StreamReader(secondInputFilePath))
                    {
                        while (!reader.EndOfStream || !reader_2.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string line_2 = reader_2.ReadLine();

                            if (line != null)
                            {
                                writer.WriteLine(line);
                            }

                            if (line_2 != null)
                            {
                                writer.WriteLine(line_2);
                            }
                        }
                    }
                }
            }
        }
    }
}
