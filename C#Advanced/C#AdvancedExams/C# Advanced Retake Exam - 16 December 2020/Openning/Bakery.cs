using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public int Count { get { return data.Count; } }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>(capacity);
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(p => p.Name == name);

            if (employee != default)
            {
                data.Remove(employee);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            Employee employee = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return employee;
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(p => p.Name == name);
            return employee;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
