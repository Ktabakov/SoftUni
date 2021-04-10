using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split();
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];

                    IIdentifiable person = new Citizen(name, age, id);
                    identifiables.Add(person);
                }
                else if (parts.Length == 2)
                {
                    string model = parts[0];
                    string id = parts[1];

                    IIdentifiable robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
                input = Console.ReadLine();
            }

            int endsWith = int.Parse(Console.ReadLine());

            identifiables.RemoveAll(p => !p.Id.EndsWith(endsWith.ToString()));

            foreach (var item in identifiables)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
