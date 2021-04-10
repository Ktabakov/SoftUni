using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(4);

            Console.WriteLine(circle.Draw());

            Shape rectangle = new Rectangle(4, 5);

            Console.WriteLine(rectangle.Draw());
        }
    }
}
