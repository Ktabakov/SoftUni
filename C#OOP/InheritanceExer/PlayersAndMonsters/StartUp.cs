using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero newHero = new Hero("koko", 24);
            DarkKnight darko = new DarkKnight("darko", 19);

            Console.WriteLine(newHero);
            Console.WriteLine(darko);
        }
    }
}