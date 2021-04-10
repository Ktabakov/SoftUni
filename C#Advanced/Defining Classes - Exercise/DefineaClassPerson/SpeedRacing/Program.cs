using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split().ToArray();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArg = command.Split().ToArray();

                string model = cmdArg[1];
                double amountKM = double.Parse(cmdArg[2]);
                int index = 0;

                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model == model)
                    {
                        index = i;
                    }
                }
                Car.Drive(cars[index], amountKM);

                command = Console.ReadLine();
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
