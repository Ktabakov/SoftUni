using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();
            int matchesCount = 1;
            int nonEqual = 0;
            int peopleNumber = 0;

            while (input != "END")
            {
                string[] cmdArg = input.Split().ToArray();
                Person person = new Person(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            int nPerson = int.Parse(Console.ReadLine());

            Person newPerson = people[nPerson - 1];

            foreach (var item in people)
            {
                if (item == newPerson)
                {
                    continue;
                }
                else
                {
                    if (newPerson.CompareTo(item) == 0)
                    {
                        matchesCount++;
                    }
                    else
                    {
                        nonEqual++;
                    }
                }
            }
            peopleNumber = people.Count;
            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesCount} {nonEqual} {peopleNumber}");
            }
        }
    }
}
