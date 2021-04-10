using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine().TrimEnd());
            Queue<int> warriorsPlates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> orcsPower = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                List<int> orcInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    warriorsPlates.Enqueue(extraPlate);
                }
                if (warriorsPlates.Count <= 0)
                {
                    break;
                }
                foreach (var item in orcInput)
                {
                    orcsPower.Push(item);
                }

                int firstPlate = warriorsPlates.Peek();
                int lastOrc = orcsPower.Peek();

                while (orcsPower.Count > 0 && warriorsPlates.Count > 0)
                {

                    if (firstPlate > lastOrc)
                    {
                        firstPlate -= lastOrc;
                        orcsPower.Pop();
                        if (orcsPower.Count <= 0)
                        {
                            break;
                        }
                        lastOrc = orcsPower.Peek();
                        if (warriorsPlates.Count == 0)
                        {
                            break;
                        }
                    }
                    else if (lastOrc > firstPlate)
                    {
                        lastOrc -= firstPlate;
                        warriorsPlates.Dequeue();
                        orcsPower.Pop();
                        orcsPower.Push(lastOrc);
                        if (warriorsPlates.Count == 0)
                        {
                            break;
                        }
                        firstPlate = warriorsPlates.Peek();
                    }
                    else if (lastOrc == firstPlate)
                    {
                        if (warriorsPlates.Count == 0)
                        {
                            break;
                        }
                        warriorsPlates.Dequeue();
                        if (orcsPower.Count > 0)
                        {
                            orcsPower.Pop();
                        }
                        break;
                    }
                }
            }
            if (warriorsPlates.Count <= 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if(orcsPower.Count > 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsPower)}");
            }
            else if (warriorsPlates.Count > 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", warriorsPlates)}");
            }
        }
    }
}
