using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Dictionary<string, int> allBombs = new Dictionary<string, int>();

            int daturaBombCount = 0;
            int cherryBombCount = 0;
            int smokeBombCount = 0;

            bool haveAll = false;

            while (bombEffects.Count > 0 && bombCasing.Count > 0 && haveAll == false)
            {
                int currentEffect = bombEffects.Dequeue();
                int currentCasing = bombCasing.Pop();

                if (currentCasing + currentEffect == 40)
                {
                    daturaBombCount++;
                }
                else if (currentCasing + currentEffect == 60)
                {
                    cherryBombCount++;
                }
                else if (currentCasing + currentEffect == 120)
                {
                    smokeBombCount++;
                }
                else
                {
                    currentCasing -= 5;

                    while (true)
                    {

                        if (currentCasing + currentEffect == 40)
                        {
                            daturaBombCount++;
                            break;
                        }
                        else if (currentCasing + currentEffect == 60)
                        {
                            cherryBombCount++;
                            break;
                        }
                        else if (currentCasing + currentEffect == 120)
                        {
                            smokeBombCount++;
                            break;
                        }
                        else
                        {
                            currentCasing -= 5;
                        }
                    }
                }

                if (smokeBombCount >= 3 && cherryBombCount >= 3 && daturaBombCount >= 3)
                {
                    haveAll = true;
                }
            }

            if (haveAll)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine("Bomb Effects: " +  string.Join(", ", bombEffects));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            allBombs.Add("Cherry Bombs", cherryBombCount);
            allBombs.Add("Datura Bombs", daturaBombCount);
            allBombs.Add("Smoke Decoy Bombs", smokeBombCount);

            allBombs.OrderBy(b => b.Key);

            foreach (var bomb in allBombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
