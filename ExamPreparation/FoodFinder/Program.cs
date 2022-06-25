using System;
using System.Collections.Generic;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> words = new List<string>()
            {
                "pear",
                "flour",
                "pork",
                "olive",
            };
            Queue<string> vowels = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<string> cons = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            HashSet<char> letters = new HashSet<char>();


            while (cons.Count > 0)
            {
                string con = cons.Pop();
                string vowel = vowels.Dequeue();

                foreach (var word in words)
                {

                    if (word.Contains(vowel))
                    {
                        letters.Add(char.Parse(vowel));
                    }

                    if (word.Contains(con))
                    {
                        letters.Add(char.Parse(con));
                    }

                }
                
                vowels.Enqueue(vowel);
            }

            List<string> foundWords = new List<string>();
            int counter = 0;

            foreach (var word in words)
            {
                bool found = true;
                foreach (var _char in word)
                {
                    if (!letters.Contains(_char))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    foundWords.Add(word);
                }
            }

            Console.WriteLine($"Words found: {foundWords.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, foundWords));


        }
    }
}
