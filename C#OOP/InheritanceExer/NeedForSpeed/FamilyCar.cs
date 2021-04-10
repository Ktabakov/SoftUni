using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class FamilyCar : Car
    {
        private const double DefaultFuelConsumption = 3;
        public FamilyCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
