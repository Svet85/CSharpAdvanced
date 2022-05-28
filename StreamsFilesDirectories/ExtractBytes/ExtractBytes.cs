namespace ExtractBytes
{
    using System;
    using System.IO;
    using System.Linq;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            int[] specificBytes = File.ReadAllLines(bytesFilePath).Select(int.Parse).ToArray();

            using (FileStream writer = new FileStream(outputPath, FileMode.OpenOrCreate))
            {
                using (var reader = new FileStream(binaryFilePath, FileMode.Open))
                {
                    int b = reader.ReadByte();

                    while (b != -1)
                    {
                        if (specificBytes.Contains(b))
                        {
                            writer.WriteByte((byte)b);
                        }

                        b = reader.ReadByte();
                    }
                }
            }

        }
    }
}
