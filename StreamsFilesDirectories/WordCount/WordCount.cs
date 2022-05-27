namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using StreamReader reader = new StreamReader(wordsFilePath);
            string[] words = reader.ReadToEnd().Split();

            for (int i = 0; i < words.Length; i++)
            {
                if (!dict.ContainsKey(words[i]))
                {
                    dict.Add(words[i], 0);
                }
            }

            using (var reader_2 = new StreamReader(textFilePath))
            {
                while (!reader_2.EndOfStream)
                {
                    string line = reader_2.ReadLine().ToLower();

                    foreach (var word in words)
                    {
                        Regex myRegex = new Regex($@"\b{word}\b");
                        var results = myRegex.Matches(line);
                        dict[word] += results.Count;
                    }
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }


        }
    }
}
