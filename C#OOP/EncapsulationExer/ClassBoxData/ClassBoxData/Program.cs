using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {        
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lenght, width, height);

                double surfaceAre = box.SurfaceArea();
                Console.WriteLine($"Surface Area - {surfaceAre:f2}");

                double lateralSurfaceArea = box.LateralSurfaceArea();
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");

                double volume = box.Volume();
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
