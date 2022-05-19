using System;
using System.Collections.Generic;
using System.Linq;

namespace P14.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(Console.ReadLine().Split(", "));

            while (playlist.Count > 0)
            {
                string[] cmd  = Console.ReadLine().Split();
                string action = cmd[0];

                if (action == "Play")
                {
                    playlist.Dequeue();
                }
                else if (action == "Add")
                {
                    string song = string.Join(" ", cmd.Skip(1));
                    
                    if (playlist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(song);
                    }
                }
                else if ( action == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
