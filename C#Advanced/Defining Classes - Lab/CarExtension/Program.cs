using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Pesho";
            car.Model = "Gosho";
            car.Year = 1999;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(0.5);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
