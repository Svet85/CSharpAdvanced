using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        
        
        public static void Main(string[] args)
        {

            List<Engine> engines = new List<Engine>();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                int power = int.Parse(info[1]);
                var engine = new Engine(model, power);
                if (info.Length == 3)
                {
                    int result = -1;
                    bool flag = int.TryParse(info[2], out  result);
                    if (flag)
                    {
                        engine.Displacement = result;
                    }
                    else
                    {
                        engine.Efficiency = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    int displacement = int.Parse(info[2]);
                    string efficiency = info[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                string engineModel = info[1];
                var engine = engines.Find(x => x.Model == engineModel);
                var car = new Car(model, engine);

                if (info.Length == 3)
                {
                    int result = -1;
                    bool flag = int.TryParse(info[2], out result);
                    if (flag)
                    {
                         car.Weight = result;
                    }
                    else
                    {
                        car.Color = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    int weight = int.Parse(info[2]);
                    string color = info[3];
                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
