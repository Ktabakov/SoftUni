using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private double weight;
        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    flourType = value;
                }
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "crispy" && valueAsLower != "chewy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArithmeticException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var bakingTechniqueToLower = this.bakingTechnique.ToLower();
            if (bakingTechniqueToLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueToLower == "cheesy")
            {
                return 1.1;
            }
            else if (bakingTechniqueToLower == "homemade")
            {
                return 1.0;
            }

            return 1;
        }

        private double GetFlourTypeModifier()
        {
            var flourTypeToLower = flourType.ToLower();

            if (flourTypeToLower == "white")
            {
                return 1.5;
            }

            return 1;
        }
    }
}
