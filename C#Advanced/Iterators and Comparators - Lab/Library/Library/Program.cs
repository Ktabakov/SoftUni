using System;

namespace IteratorsAndComparators
{
     public class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
                {
                    new Book("SeTaq", 1943, new string[]{"A.A. FDSFS"}),
                    new Book("Under the Dome", 2000, "Stephen King")
                };
            Library myLibrary = new Library(books);
            
            

            foreach (var item in myLibrary)
            {
                Console.WriteLine(item);
            }
        }
    }
}
