using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age)
            : this()
        {
            Age = age;
        }
        public Person(string name, int age)
            : this (age)
        {
            Age = age;
            Name = name;
        }
    }
}
