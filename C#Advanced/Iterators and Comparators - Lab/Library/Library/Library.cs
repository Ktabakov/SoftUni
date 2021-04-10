using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] books)
        {
            IComparer<Book> comparer = new BookComparer();
            this.books = new SortedSet<Book>(books, comparer);
        }
        public Library()
        {
            IComparer<Book> comparer = new BookComparer();
            books = new SortedSet<Book>(comparer);  
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
