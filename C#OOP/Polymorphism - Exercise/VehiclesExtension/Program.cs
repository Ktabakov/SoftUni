using System;

namespace MyVehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[1] == nameof(Car))
                {
                    try
                    {
                        if (commands[0] == "Drive")
                        {
                            car.Drive(double.Parse(commands[2]));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            car.Refuel(double.Parse(commands[2]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (commands[1] == nameof(Truck))
                {
                    try
                    {
                        if (commands[0] == "Drive")
                        {
                            truck.Drive(double.Parse(commands[2]));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (commands[1] == nameof(Bus))
                {
                    try
                    {
                        if (commands[0] == "Drive")
                        {
                            bus.Drive(double.Parse(commands[2]));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            bus.Refuel(double.Parse(commands[2]));
                        }
                        else if (commands[0] == "DriveEmpty")
                        {
                            ((Bus)bus).DriveEmpty(double.Parse(commands[2]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        public static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            Vehicle vehicle = default;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
