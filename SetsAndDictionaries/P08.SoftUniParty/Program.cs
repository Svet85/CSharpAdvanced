using System;
using System.Collections.Generic;

namespace P08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                string guestNumber = input;

                if (guestNumber.Length == 8)
                {
                    if (char.IsDigit(guestNumber[0]))
                    {
                        VIP.Add(guestNumber);
                    }
                    else
                    {
                        regular.Add(guestNumber);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    VIP.Remove(input);
                }
                else
                {
                    regular.Remove(input);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count + regular.Count);
            foreach (var guest in VIP)
            {
                Console.WriteLine(guest);
            }
            
            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
