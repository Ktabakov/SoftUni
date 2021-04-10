using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public int Count { get { return data.Count; } }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>(Capacity);
        }

        public void Add(Racer racer)
        {
            if(data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            if (racer != default)
            {
                data.Remove(racer);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            Racer racer = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return racer;
        }
        public Racer GetRacer(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            return racer;
        }
        public Racer GetFastestRacer()
        {
            Racer fastestRacer = data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
            return fastestRacer;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
