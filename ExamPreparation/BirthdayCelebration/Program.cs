using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int guest = guests.Dequeue();
                int plate = plates.Pop();

                if (guest <= plate)
                {
                    wastedFood += plate - guest;
                }
                else if (guest > plate)
                {
                    guest -= plate;
                    while (guest > 0 && plates.Count > 0)
                    {
                        plate = plates.Pop();
                        guest -= plate;

                        if (guest < 0)
                        {
                            wastedFood -= guest;
                            break;
                        }
                    }
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
