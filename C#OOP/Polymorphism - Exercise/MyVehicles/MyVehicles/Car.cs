using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public class Car : Vehicle
    {
        private const double carAir = 0.9;
        public Car(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm, carAir)
        {
        }
        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
