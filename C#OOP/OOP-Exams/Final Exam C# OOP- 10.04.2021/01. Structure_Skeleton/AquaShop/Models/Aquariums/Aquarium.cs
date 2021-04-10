using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);

                }
                this.name = value;
            }
        }

        public int Capacity { get; protected set; }

        public int Comfort => this.decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => (ICollection<IDecoration>)this.decorations;

        public ICollection<IFish> Fish => (ICollection<IFish>)this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count < Capacity)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var item in this.fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (fish.Count <= 0)
            {
                sb.AppendLine($"{this.Name} ({this.GetType().Name}): ".TrimEnd());
                sb.AppendLine("Fish: none".TrimEnd());
                sb.AppendLine($"Decorations: {this.decorations.Count}".TrimEnd());
                sb.AppendLine($"Comfort: {this.Comfort}".TrimEnd());

                return sb.ToString().TrimEnd();
            }
            else
            {
                sb.AppendLine($"{this.Name} ({this.GetType().Name}): ".TrimEnd());
                List<string> fishNames = new List<string>();
                foreach (var item in this.fish)
                {
                    fishNames.Add(item.Name);
                }
                sb.AppendLine($"Fish: {string.Join(", ", fishNames).TrimEnd()}"); 
                sb.AppendLine($"Decorations: {this.decorations.Count}".TrimEnd());
                sb.AppendLine($"Comfort: {this.Comfort}".TrimEnd());

                return sb.ToString().TrimEnd();
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
