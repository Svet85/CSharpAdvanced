namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var writer = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
                {

                    using (var writer_2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[reader.Length / 2];
                        reader.Read(buffer);
                        writer.Write(buffer);
                        if (reader.Length % 2 != 0)
                        {
                            writer.WriteByte((byte)reader.ReadByte());
                        }
                        reader.Read(buffer);
                        writer_2.Write(buffer);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var writer = new FileStream(joinedFilePath, FileMode.OpenOrCreate))
            {
                using (var reader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    using (var reader_2 = new FileStream(partTwoFilePath, FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int count = reader.Read(buffer);
                            if (count == 0)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, count);
                        }

                        while (true)
                        {
                            int count = reader_2.Read(buffer);
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
}