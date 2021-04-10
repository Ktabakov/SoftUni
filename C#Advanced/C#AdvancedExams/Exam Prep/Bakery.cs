using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery<T>
    {
        public T[] Data = null;

        public int Count { get; private set; }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public Employee Employee { get; set; }




        public Bakery(string name, int capacity)
        {
            Name = name;
            Count = 0;
            Capacity = capacity;
            Data = new T[capacity];            
        }

        public void Add(Employee employees)
        {
            Data[Count] = employees;
            Count++;
        }
        
        public bool Remove(string name)
        {
            bool isFound = false;
            for (int i = 0; i < Count; i++)
            {
                if (Data[i] == name)
                {
                    isFound = true;
                    Data[i] = default;
                }
            }
            

            return isFound;
        }



        public void ForEach()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(Data[i]);
            }
        }
    }
}
