using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> ingridients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<string, int> allBakary = new Dictionary<string, int>();

            int breadCounter = 0;
            int cakeCounter = 0;
            int pastryCounter = 0;
            int fruitPieCounter = 0;

            bool haveAll = false;

            while (liquids.Count > 0 && ingridients.Count > 0)
            {
                int firstLiquid = liquids.Dequeue();
                int lastIngridient = ingridients.Pop();
                int sum = firstLiquid + lastIngridient;

                if (sum == 25)
                {
                    breadCounter++;
                }
                else if (sum == 50)
                {
                    cakeCounter++;
                }
                else if (sum == 75)
                {
                    pastryCounter++;
                }
                else if (sum == 100)
                {
                    fruitPieCounter++;
                }
                else
                {
                    lastIngridient += 3;
                    ingridients.Push(lastIngridient);
                }
            }
            if (breadCounter > 0 && cakeCounter > 0 && pastryCounter > 0 && fruitPieCounter > 0)
            {
                haveAll = true;
            }

            if (haveAll)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingridients.Count > 0)
            {
                Console.WriteLine("Ingredients left: " + string.Join(", ", ingridients));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            allBakary.Add("Bread", breadCounter);
            allBakary.Add("Cake", cakeCounter);
            allBakary.Add("Fruit Pie", fruitPieCounter);
            allBakary.Add("Pastry", pastryCounter);

            foreach (var item in allBakary.OrderBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        
    }
}
