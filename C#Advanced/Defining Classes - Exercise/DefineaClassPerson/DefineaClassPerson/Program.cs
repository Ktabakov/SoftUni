using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateFirst = Console.ReadLine();
            string dateSecond = Console.ReadLine();

            int result = DateModifier.GetDifference(dateFirst, dateSecond);
            Console.WriteLine(Math.Abs(result));
        }
    }
}
