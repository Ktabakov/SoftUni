using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            foreach (var item in n)
            {
                numbers.Push(item);
            }

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] cmdArg = input.Split().ToArray();
                string cmd = cmdArg[0].ToLower();

                if (cmd == "add")
                {
                    int first = int.Parse(cmdArg[1]);
                    int second = int.Parse(cmdArg[2]);

                    numbers.Push(first);
                    numbers.Push(second);
                }
                else if (cmd == "remove")
                {
                    int count = int.Parse(cmdArg[1]);

                    if (count > numbers.Count)
                    {
                        input = Console.ReadLine().ToLower();
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
