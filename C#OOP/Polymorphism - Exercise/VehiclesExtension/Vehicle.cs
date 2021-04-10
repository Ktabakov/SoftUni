using System;
using System.Collections.Generic;
using System.Text;

namespace MyVehicles
{
    public abstract class Vehicle
    {
        protected  Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity, double airconditionerModifier)
        {
            Fuel = fuelQuantity;
            LitersPerKm = litersPerKm;
            AirconditionerModifier = airconditionerModifier;
            TankCapacity = tankCapacity;
        }

        private double fuel;
        public double TankCapacity { get; private set; }
        private double AirconditionerModifier { get; set; }

        public double Fuel
        {
            get => this.fuel;
            protected set
            {
                if (fuel > TankCapacity)
                {
                    fuel = 0;
                }
                else
                {
                    fuel = value;
                }
            }
        }

        public double LitersPerKm { get; private set; }

        public virtual void Drive(double distance)
        {
            double requiredFuel = (this.LitersPerKm + AirconditionerModifier) * distance;

            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.Fuel -= requiredFuel;
        }

        public virtual void Refuel(double liters)
        {
            if (liters + Fuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.Fuel += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}"; 
        }
    }
}
