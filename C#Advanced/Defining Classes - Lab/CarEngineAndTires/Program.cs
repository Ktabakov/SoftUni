using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tireInfo = Console.ReadLine();

            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();
            while (tireInfo != "No more tires")
            {
                string[] argCmd = tireInfo.Split().ToArray();
                Tire[] tires = new Tire[]
                {
                    new Tire(int.Parse(argCmd[0]),double.Parse(argCmd[1])),
                    new Tire(int.Parse(argCmd[2]),double.Parse(argCmd[3])),
                    new Tire(int.Parse(argCmd[4]),double.Parse(argCmd[5])),
                    new Tire(int.Parse(argCmd[6]),double.Parse(argCmd[7])),
                };

                allTires.Add(tires);
                tireInfo = Console.ReadLine();
            }

            string engineInfo = Console.ReadLine();

            while (engineInfo != "Engines done")
            {
                string[] cmdArg = engineInfo.Split().ToArray();
                int horsePower = int.Parse(cmdArg[0]);
                double cubicCapacity = double.Parse(cmdArg[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                allEngines.Add(engine);

                engineInfo = Console.ReadLine();
            }

            string finalInput = Console.ReadLine();

            while (finalInput != "Show special")
            {
                string[] argCmd = finalInput.Split().ToArray();

                string make = argCmd[0];
                string model = argCmd[1];
                int year = int.Parse(argCmd[2]);
                double fuelQuantity = double.Parse(argCmd[3]);
                double fuelConsumption = double.Parse(argCmd[4]);
                int engineIndex = int.Parse(argCmd[5]);
                int tirsIndex = int.Parse(argCmd[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tirsIndex]);
                allCars.Add(car);

                finalInput = Console.ReadLine();
            }

            foreach (var item in allCars)
            {
                if (item.isSpecial(item))
                {
                    item.Drive(20);
                    Console.WriteLine(item);
                }
            }
        }
    }
}
