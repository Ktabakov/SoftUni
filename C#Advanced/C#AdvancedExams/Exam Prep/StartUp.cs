namespace BakeryOpenning
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bakery bakery = new Bakery("Barny", 10);
            Employee employee = new Employee("Stephan", 40, "Bulgaria");
            Employee employee1 = new Employee("Joro", 20, "Pere");
            Employee employee2 = new Employee("Misho", 30, "PEer");

            bakery.Add(employee);
            bakery.Add(employee1);
            bakery.Add(employee2);

            bakery.ForEach();
        }
    }
}
