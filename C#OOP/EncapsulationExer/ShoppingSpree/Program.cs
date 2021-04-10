using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                 people = ReadPeople();
                 products = ReadProducts();
            }
            catch (ArgumentException exeption)
            {
                Console.WriteLine(exeption.Message);
                return;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmdArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = cmdArg[0];
                string productName = cmdArg[1];

                Person person = people[personName];
                Product product = products[productName];     

                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            foreach (var item in people.Values)
            {
                Console.WriteLine(item);
            }           
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in peopleInfo)
            {
                string[] thePerson = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = thePerson[0];
                decimal money = decimal.Parse(thePerson[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();

            string[] foodInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in foodInfo)
            {
                string[] theFood = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = theFood[0];
                decimal cost = decimal.Parse(theFood[1]);

                result[name] = new Product(name, cost);
            }
            return result;
        }
    }
}
