using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] rawData = Console.ReadLine().Split().ToArray();
                string model = rawData[0];
                Engine engine = new Engine(double.Parse(rawData[1]), double.Parse(rawData[2]));
                Cargo cargo = new Cargo(double.Parse(rawData[3]), rawData[4]);

                Tire[] tires = new Tire[]
                {
                new Tire(double.Parse(rawData[5]), int.Parse(rawData[6])),
                new Tire(double.Parse(rawData[7]), int.Parse(rawData[8])),
                new Tire(double.Parse(rawData[9]), int.Parse(rawData[10])),
                new Tire(double.Parse(rawData[11]), int.Parse(rawData[12])),
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            Car.PrintCars(cars, command);

        }
    }
}
