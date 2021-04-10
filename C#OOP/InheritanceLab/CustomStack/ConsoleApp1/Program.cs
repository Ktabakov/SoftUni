using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();

            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(new List<string>() { "joro", "pesho", "misho" });

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
