using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> numbers = new ListyIterator<string>(items);

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(numbers.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        numbers.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(numbers.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in numbers)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}
