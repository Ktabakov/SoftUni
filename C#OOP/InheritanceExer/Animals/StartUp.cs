using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            while (input != "Beast!")
            {

                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if(string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (input == "Tomcat")
                {
                    Tomcat tom = new Tomcat(name, age);
                    Console.WriteLine(tom);
                    Console.WriteLine(tom.ProduceSound());
                }
                else if (input == "Kitten")
                {
                    Kitten kit = new Kitten(name, age);
                    Console.WriteLine(kit);
                    Console.WriteLine(kit.ProduceSound());
                }

                input = Console.ReadLine();
            }
        }
    }
}
