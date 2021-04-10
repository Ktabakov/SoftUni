using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake myLake = new Lake(nums);

            Console.WriteLine(string.Join(", ", myLake));

        }
    }
}
