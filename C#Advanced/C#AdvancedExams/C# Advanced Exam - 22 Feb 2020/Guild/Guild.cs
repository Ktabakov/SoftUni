using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public int Count { get { return roster.Count; } }

        public Player Player { get; set; }

        public int Capacity { get; set; }

        public string Name { get; set; }

        public Guild(string name, int capacity)
        {
            roster = new List<Player>(Capacity);
            Capacity = capacity;
            Name = name;
        }
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
            
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != default)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != default || player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != default || player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string someClass)
        {
            List<Player> classPlayers = new List<Player>();

            foreach (var item in roster)
            {
                if (item.Class == someClass)
                {
                    classPlayers.Add(item);
                }
            }
            roster.RemoveAll(p => p.Class == someClass);

            return classPlayers.ToArray();
        }
        public string Report()
        {
            StringBuilder newSb = new StringBuilder();

            newSb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in roster)
            {
                newSb.AppendLine(player.ToString());
            }

            return newSb.ToString().TrimEnd();
        }
    }
}
