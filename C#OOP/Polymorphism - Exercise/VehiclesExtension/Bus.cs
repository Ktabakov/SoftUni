using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public class Bus : Vehicle
    {
        private const double withAir = 1.4;
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity, withAir)
        {
        }

        public void DriveEmpty(double distance)
        {
            double requiredFuel = (this.LitersPerKm) * distance;

            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.Fuel -= requiredFuel;
        }
    }
}
