using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {



            string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var collection = new ListyIterator<string>(elements);

            string input = Console.ReadLine();
            try
            {
                while (input != "END")
                {

                    if (input == "Move")
                    {
                        Console.WriteLine(collection.Move());
                    }
                    else if (input == "Print")
                    {
                        collection.Print();
                    }
                    else if (input == "HasNext")
                    {
                        Console.WriteLine(collection.HasNext());
                    }
                    else if (input == "PrintAll")
                    {
                        foreach (var item in collection)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
