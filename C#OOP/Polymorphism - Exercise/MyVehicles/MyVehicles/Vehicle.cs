using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public abstract class Vehicle
    {
        protected  Vehicle(double fuelQuantity, double litersPerKm, double airconditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm;
            AirconditionerModifier = airconditionerModifier;
        }

        private double AirconditionerModifier { get; set; }

        public double FuelQuantity { get; set; }

        public double LitersPerKm { get; set; }

        public void Drive(double distance)
        {
            double requiredFuel = (this.LitersPerKm + AirconditionerModifier) * distance;

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}"; 
        }
    }
}
