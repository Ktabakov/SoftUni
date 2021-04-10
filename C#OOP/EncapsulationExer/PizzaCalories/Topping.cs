using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private double weight;
        private string name;

        public Topping(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "meat" && valueAsLower != "veggies" && valueAsLower != "cheese" && valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                weight = value;
            }
        }

        public double GetCalories()
        {
            var modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();

            if (nameToLower == "meat")
            {
                return 1.2;
            }
            else if (nameToLower == "veggies")
            {
                return 0.8;
            }
            else if (nameToLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
