using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double  FuelQuantity { get; set; }

        public double  FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double fuelToConsume = (FuelConsumption/100) * distance;
            if (FuelQuantity - fuelToConsume > 0)
            {
                FuelQuantity -= fuelToConsume;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}";
        }

        public bool isSpecial(Car car)
        {
            double tiresSum = sumAlltires(car);
            if (car.Year >= 2017 && car.Engine.HorsePower > 330 && tiresSum >= 9 && tiresSum <= 10)
            {
                return true;
            }
            return false;
        }

        private double sumAlltires(Car car)
        {
            double tiresSum = 0;
            foreach (var item in car.Tires)
            {
                tiresSum += item.Pressure;
            }
            return tiresSum;
        }

        public override string ToString()
        {
            return
                $"Make: {Make}\nModel: {Model}\nYear: {Year}\nHorsePowers: {Engine.HorsePower}\nFuelQuantity: {FuelQuantity}";
        }
    }
}
