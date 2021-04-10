using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public static void PrintCars(List<Car> cars, string command)
        {
            
            foreach (var car in cars)
            {
                bool badPressure = false;

                foreach (var tire in car.Tires)
                {
                    if (tire.TirePressure < 1)
                    {
                        badPressure = true;
                    }
                }
                if (command == "fragile" && badPressure == true)
                {                   
                    Console.WriteLine(car.Model);
                }
                else if (command == "flamable" && car.Engine.EnginePower > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }

    }
}
