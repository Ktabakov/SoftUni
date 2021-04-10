using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;       
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            return $"{string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name)}";
            //$"Successfully added {aquariumType}."
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration deco = null;
            if (decorationType == "Ornament")
            {
                deco = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                deco = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(deco);
            return $"{string.Format(OutputMessages.SuccessfullyAdded, deco.GetType().Name)}";
            //$"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            IAquarium aqua = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (aqua.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                aqua.AddFish(fish);
                return $"{string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aqua.Name)}";
                    //$"Successfully added {fishType} to {aquariumName}.";
            }
            else if (aqua.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                aqua.AddFish(fish);
                return $"{string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aqua.Name)}";
                //$"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return $"{OutputMessages.UnsuitableWater}";
                    //"Water not suitable.";
            }
            
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aqua = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value = aqua.Fish.Sum(f => f.Price) + aqua.Decorations.Sum(d => d.Price);

            return $"{string.Format(OutputMessages.AquariumValue, aqua.Name, value)}";
                //$"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium auqa = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            auqa.Feed();

            return $"{string.Format(OutputMessages.FishFed, auqa.Fish.Count)}";
                //$"Fish fed: {auqa.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration deco = decorations.FindByType(decorationType);
            IAquarium aqua = aquariums.FirstOrDefault(c => c.Name == aquariumName);

            if (deco != default)
            {
                decorations.Remove(deco);
                aqua.AddDecoration(deco);
                return $"{string.Format(OutputMessages.EntityAddedToAquarium, deco.GetType().Name, aqua.Name)}";
                    //$"Successfully added {decorationType} to {aquariumName}.";
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
