using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return (IReadOnlyCollection<ICar>)this.cars;
        }

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(c => c.Model == name);
            return car;
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
