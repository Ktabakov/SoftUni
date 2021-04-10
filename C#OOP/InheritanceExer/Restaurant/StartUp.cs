using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffee = new Coffee("costa", 50);

            System.Console.WriteLine(coffee.Price);
        }
    }
}