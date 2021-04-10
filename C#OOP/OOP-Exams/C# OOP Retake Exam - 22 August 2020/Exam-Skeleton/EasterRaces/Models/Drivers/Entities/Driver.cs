using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                if (this.Car != default)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddCar(ICar car)
        {
            if (car != default)
            {
                this.Car = car;
                //maybe see to set CanParticipate to true?
            }
            else
            {
                throw new ArgumentException("Car cannot be null.");
            }
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
