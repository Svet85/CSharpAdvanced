using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int mealsStartingCount = meals.Count;

            while (meals.Count > 0 && dailyCalories.Count > 0)
            {
                int mealCalories = MealCalories(meals.Peek());
                int daily = dailyCalories.Peek();

                if (daily - mealCalories == 0)
                {
                    meals.Dequeue();
                    dailyCalories.Pop();
                }
                else if (daily - mealCalories > 0)
                {
                    int leftDaily = daily - mealCalories;
                    meals.Dequeue();
                    dailyCalories.Pop();
                    dailyCalories.Push(leftDaily);
                }
                else if (daily - mealCalories < 0)
                {
                    int mealLeft = mealCalories - daily;
                    meals.Dequeue();
                    dailyCalories.Pop();
                    if (dailyCalories.Count > 0)
                    {
                        mealCalories = dailyCalories.Pop() - mealLeft;
                        dailyCalories.Push(mealCalories);
                    }
                }
            }

            if (dailyCalories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsStartingCount - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsStartingCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }
        }

        public static int MealCalories(string meal)
        {
            int calories = 0;
            switch (meal)
            {
                case "salad":
                    calories = 350;
                    break;
                case "soup":
                    calories = 490;
                    break;
                case "pasta":
                    calories = 680;
                    break;
                case "steak":
                    calories = 790;
                    break;
                default:
                    break;
            }

            return calories;
        }
    }
}
