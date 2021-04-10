using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> playersByName;

        public Team(string name)
        {
            Name = name;
            this.playersByName = new Dictionary<string, Player>();
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
                else
                {
                    name = value;
                }
            }
        }
        public void AddPlayer(Player player)
        {
            this.playersByName.Add(player.Name, player);
        }
        public void RemovePlayer(string playerName)
        {
            if (!this.playersByName.ContainsKey(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.playersByName.Remove(playerName);
        }
        public double AverageRaiting
        {
            get
            {
                if (this.playersByName.Count == 0)
                {
                    return 0;
                }
                return Math.Round(this.playersByName.Values.Average(p => p.AvarageSkillPoints));
            }
        }
    }
}
