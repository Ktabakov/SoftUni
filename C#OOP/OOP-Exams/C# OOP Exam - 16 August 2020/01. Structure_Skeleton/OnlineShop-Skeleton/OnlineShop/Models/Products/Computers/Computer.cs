using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        private decimal price;
        private double ovveralPerformance;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.price = price;
            this.ovveralPerformance = overallPerformance;
        }

        // not sure at allll!!....
        public new double OverallPerformance => components.Sum(x => x.OverallPerformance) / components.Count + ovveralPerformance;

        //not sure at all...
         public new decimal Price => this.price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);
        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)peripherals;

        public void AddComponent(IComponent component)
        {
            IComponent comp = components.FirstOrDefault(c => c == component);

            //not sure
            if (comp != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, comp.GetType().Name, this.GetType().Name, comp.Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral peri = peripherals.FirstOrDefault(p => p.GetType().Name == peripheral.GetType().Name);

            if (peri != default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peri.GetType().Name, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent comp = components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (components.Count == 0 || comp == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            components.Remove(comp);
            return comp;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peri = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (peripherals.Count == 0 || peri == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(peri);
            return peri;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({components.Count}):");
            foreach (var item in components)
            {
                sb.AppendLine($"  {item.ToString().TrimEnd()}");
            }
            
            if (peripherals.Count > 0)
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(c => c.OverallPerformance):f2}):");
                foreach (var item in peripherals)
                {
                    sb.AppendLine($"  {item.ToString().TrimEnd()}");
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance (0.00):");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
