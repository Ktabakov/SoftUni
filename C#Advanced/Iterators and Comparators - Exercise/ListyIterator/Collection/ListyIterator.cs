using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items)
        {
            this.items = items;
            index = 0;
        }
        public ListyIterator(params T[] items)
        {
            this.items = items.ToList();
            index = 0;
        }

        public bool HasNext() => this.index< this.items.Count - 1;

        public bool Move()
        {
            bool hasNext = this.HasNext();
            if (HasNext())
            {
                index++;
            }
            return hasNext;
        }
        public void Print()
        {
            if (index >= items.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }
    }
}
