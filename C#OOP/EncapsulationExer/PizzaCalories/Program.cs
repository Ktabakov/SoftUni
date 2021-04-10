using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

                var doughData = Console.ReadLine().Split();

                var flourType = doughData[1];
                var bakingTechnique = doughData[2];
                double weight = double.Parse(doughData[3]);

                var dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);


                string input = Console.ReadLine();

                while (input != "END")
                {
                    var parts = input.Split();

                    var toppingName = parts[1];
                    int toppingWeight = int.Parse(parts[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
