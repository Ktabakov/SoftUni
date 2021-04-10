using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myList = new RandomList();

            myList.Add("Pesho");
            myList.Add("Ivo");
            myList.Add("Misho");
            myList.Add("Marriika");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.RandomString());
            }
            myList.Remove(myList.RandomString());

            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.RandomString());
            }
        }
    }
}
