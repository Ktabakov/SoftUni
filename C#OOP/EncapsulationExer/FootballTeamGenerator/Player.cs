using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinRange = 0;
        private const int MaxRange = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value >= MinRange && value <= MaxRange)
                {
                    endurance = value;
                }
                else
                {
                    throw new ArgumentException($"Endurance should be between {MinRange} and {MaxRange}.");
                }
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value >= MinRange && value <= MaxRange)
                {
                    sprint = value;
                }
                else
                {
                    throw new ArgumentException($"Sprint should be between {MinRange} and {MaxRange}.");
                }
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value >= MinRange && value <= MaxRange)
                {
                    dribble = value;
                }
                else
                {
                    throw new ArgumentException($"Dribble should be between {MinRange} and {MaxRange}.");
                }               
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (value >= MinRange && value <= MaxRange)
                {
                    passing = value;
                }
                else
                {
                    throw new ArgumentException($"Passing should be between {MinRange} and {MaxRange}.");
                }
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value >= MinRange && value <= MaxRange)
                {
                    shooting = value;
                }
                else
                {
                    throw new ArgumentException($"Shooting should be between {MinRange} and {MaxRange}.");
                }
            }
        }
        public double AvarageSkillPoints
        {
            get => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0); 
        }
    }
}
