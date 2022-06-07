using System;

namespace ImplementingDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new MyDoublyLinkedList();

            linkedList.AddHead(1);
            linkedList.AddHead(2);
            linkedList.AddHead(3);
            linkedList.RemoveHead();
            linkedList.AddTail(7);
            linkedList.AddTail(6);
            linkedList.AddTail(5);
            linkedList.RemoveTail();
            linkedList.Foreach();
            var array = linkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));



        }
    }
}
