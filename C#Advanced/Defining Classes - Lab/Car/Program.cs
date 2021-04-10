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
        }
    }
}
