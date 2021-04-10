using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int wreathCount = 0;
            int remaningValue = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();

                int sum = lili + rose;
                if (sum == 15)
                {
                    wreathCount++;
                }
                else if (sum < 15)
                {
                    remaningValue += sum;
                }
                else if (sum % 2 == 0)
                {
                    remaningValue += 14;
                }
                else
                {
                    wreathCount++;
                }
            }

            wreathCount += remaningValue / 15;

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
