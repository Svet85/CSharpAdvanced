using System;
using System.Collections.Generic;

namespace P17._SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> editor = new Stack<string>();
            editor.Push("");

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                int action = int.Parse(cmd[0]);

                if (action == 1)
                {
                    string text = cmd[1];
                    string appended = editor.Peek() + text;
                    editor.Push(appended);
                }
                else if (action == 2)
                {
                    int elementsCount = int.Parse(cmd[1]);
                    string text = editor.Peek();
                    string editedstring = text.Remove(text.Length - elementsCount);
                    editor.Push(editedstring);
                }
                else if (action == 3)
                {
                    int index = int.Parse(cmd[1]) - 1;
                    string text = editor.Peek();
                    Console.WriteLine(text[index]);
                }
                else if (action == 4)
                {
                    editor.Pop();
                }
            }
        }
    }
}
