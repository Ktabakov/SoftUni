using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> foodList = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 3)
                {
                    IBuyer rebel = new Rebel(parts[0], int.Parse(parts[1]), parts[2]);
                    foodList.Add(rebel);
                }
                else if (parts.Length == 4)
                {
                    IBuyer citizen = new Citizen(parts[0], int.Parse(parts[1]), parts[2], parts[3]);
                    foodList.Add(citizen);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
   

                if (foodList.FirstOrDefault(p => p.Name == name) != default)
                {
                    foreach (var item in foodList)
                    {
                        if (item.Name == name)
                        {
                            item.BuyFood();
                        }
                    }
                }
                name = Console.ReadLine();
            }

            Console.WriteLine(foodList.Sum(p => p.Food));
        }
    }
}
