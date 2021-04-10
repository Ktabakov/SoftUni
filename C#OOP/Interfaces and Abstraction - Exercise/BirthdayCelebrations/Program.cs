using System;
using System.Collections.Generic;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthdate> birthdates = new List<IBirthdate>();

            while (input != "End")
            {
                string[] parts = input.Split();
                if (parts[0] == "Citizen")
                {
                    IBirthdate citizen = new Citizen(parts[1], int.Parse(parts[2]), parts[3], parts[4]);
                    birthdates.Add(citizen);
                }
                else if (parts[0] == "Pet")
                {
                    IBirthdate pet = new Pet(parts[1], parts[2]);
                    birthdates.Add(pet);
                }
                else if (parts[0] == "Robot")
                {
                    Robot robot = new Robot(parts[1], parts[2]);
                }

                input = Console.ReadLine();
            }
            int year = int.Parse(Console.ReadLine());

            birthdates.RemoveAll(p => !p.Birthday.Contains(year.ToString()));

            if (birthdates.Count != 0)
            {
                foreach (var item in birthdates)
                {
                    Console.WriteLine(item.Birthday);
                }
            }

        }
    }
}
