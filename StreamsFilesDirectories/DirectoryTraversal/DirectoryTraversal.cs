namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"/report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var dir = new DirectoryInfo(inputFolderPath);
            var files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
            Dictionary<string, List<FileInfo>> contents = new Dictionary<string, List<FileInfo>>();
            foreach (var item in files)
            {
                if (contents.ContainsKey(item.Extension) == false)
                {
                    contents.Add(item.Extension, new List<FileInfo>());
                }
                    
                contents[item.Extension].Add(item);
            }

            contents = contents.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value.OrderBy(x => x.Length).ToList()).ToDictionary(x => x.Key, x => x.Value.ToList());

            string text = Textprocessing(contents);

            return text;
        }

        public static string Textprocessing(Dictionary<string, List<FileInfo>> contents)
        {
            var text = new StringBuilder();
            foreach (var item in contents)
            {
                text.AppendLine(item.Key);
                foreach (var file in item.Value)
                {
                    double size = (double)file.Length / 1024;
                    text.AppendLine($"--{file.Name} - {size}kb");
                }
            }
            
            return text.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(path, textContent);

        }
    }
}
