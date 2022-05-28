namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);

            long sizeKB = 0;
            foreach (var file in files)
            {
                sizeKB += file.Length;
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{(double)sizeKB / 1024} KB");
            }

        }
    }
}
