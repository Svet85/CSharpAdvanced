using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingDoublyLinkedList
{
    class MyDoublyLinkedList
    {
        public int Count { get; private set; }

        private LinkedListNode Head { get; set; }
        private LinkedListNode Tail { get; set; }

        public void AddHead(int value)
        {
            if (Count == 0)
            {
                var newNode = new LinkedListNode(value);
                Head = Tail = newNode;
            }
            else
            {
                var newNode = new LinkedListNode(value);
                var previousHead = this.Head;
                previousHead.Previous = newNode;
                newNode.Next = previousHead;
                Head = newNode;
            }

            Count++;
        }

        public void AddTail(int value)
        {
            var newNode = new LinkedListNode(value);

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                var previousTail = Tail;
                Tail = newNode;
                newNode.Previous = previousTail;
                previousTail.Next = newNode;
            }

            Count++;
        }

        public int RemoveHead()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var removedHead = Head;

            if (Head.Next == null)
            {
                Head = Tail = null;
            }
            else
            {
                var newHead = Head.Next;
                removedHead.Next = null;
                newHead.Previous = null;
                Head = newHead;
            }

            Count--;
            return removedHead.Value;
        }


        public int RemoveTail()
        {
            if (Count == 0)
            {
                 throw new InvalidOperationException();
            }
            
            var removedTail = Tail;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var newTail = Tail.Previous;
                newTail.Next = null;
                Tail = newTail;
                removedTail.Previous = null;
            }
            
            Count--;
            return removedTail.Value;
        }

        public void Foreach()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var currentNode = Head;
                while (currentNode.Next != null)
                {
                    Console.WriteLine(currentNode.Value);
                    currentNode = currentNode.Next;
                }
                Console.WriteLine(Tail.Value);
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            var currentNode = Head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = currentNode.Value;
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
            }

            return array;

        }



        public class LinkedListNode
        {
            public LinkedListNode(int value)
            {
                Value = value;
            }
            public int Value { get; set; }
            public LinkedListNode Next { get; set; }
            public LinkedListNode Previous { get; set; }
        }


    }
}
