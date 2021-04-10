using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string gameClass = Console.ReadLine();

                BaseHero hero = default;

                if (gameClass == nameof(Paladin))
                {
                    hero = new Paladin(name);
                }
                else if (gameClass == nameof(Druid))
                {
                    hero = new Druid(name);
                }
                else if (gameClass == nameof(Rogue))
                {
                    hero = new Rogue(name);
                }
                else if (gameClass == nameof(Warrior))
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            int allPowersSum = heroes.Sum(p => p.Power);

            heroes.ForEach(p => Console.WriteLine(p.CastAbility()));

            if (allPowersSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
