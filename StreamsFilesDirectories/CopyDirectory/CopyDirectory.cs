namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var files = new DirectoryInfo(inputPath).GetFiles("*", SearchOption.TopDirectoryOnly);

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string outPath = string.Empty;
            foreach (var item in files)
            {
                outPath = $@"{outputPath}\{item.Name}";
                File.Copy(item.FullName, outPath);
            }
        }
    }
}
