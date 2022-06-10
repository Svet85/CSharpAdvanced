using System;

namespace ImplementingStackAndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lilst = new MyList();
            Console.WriteLine(lilst.Count);
            Console.WriteLine(lilst.Capacity);
            lilst.AddElement(0);
            lilst.AddElement(0);
            lilst.AddElement(0);
            lilst.AddElement(0);
            Console.WriteLine(lilst.Count);
            Console.WriteLine(lilst.Capacity);

        }
    }
}
