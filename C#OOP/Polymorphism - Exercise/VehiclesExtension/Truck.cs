using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public class Truck : Vehicle
    {
        private const double truckAir = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity, truckAir)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters + Fuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.Fuel += liters * 0.95;
        }
    }
}
