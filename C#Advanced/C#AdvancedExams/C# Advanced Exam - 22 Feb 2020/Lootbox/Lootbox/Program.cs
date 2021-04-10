using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int claimedItems = 0;

            while (true)
            {
                if (firstBox.Count <= 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                else if (secondBox.Count <= 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int firstBoxItem = firstBox.Peek();
                int secondBoxItem = secondBox.Peek();

                int sum = firstBoxItem + secondBoxItem;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBoxItem = secondBox.Pop();
                    firstBox.Enqueue(secondBoxItem);
                }
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
