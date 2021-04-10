using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }


        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = new Person();
            int oldest = int.MinValue;
            foreach (var person in People)
            {
                if (person.Age > oldest)
                {
                    oldest = person.Age;
                    oldestPerson = person;

                }
            }
            return oldestPerson;
        }

    }
}
