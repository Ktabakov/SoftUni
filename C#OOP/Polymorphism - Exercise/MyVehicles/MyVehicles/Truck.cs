using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public class Truck : Vehicle
    {
        private const double truckAir = 1.6;
        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm, truckAir)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
