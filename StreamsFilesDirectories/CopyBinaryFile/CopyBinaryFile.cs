namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var reader = new FileStream(inputFilePath,FileMode.Open))
            {
                using (var writer = new FileStream(outputFilePath, FileMode.OpenOrCreate))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int count = reader.Read(buffer);

                        if (count == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, count);
                    }
                }
            }
        }
    }
}
