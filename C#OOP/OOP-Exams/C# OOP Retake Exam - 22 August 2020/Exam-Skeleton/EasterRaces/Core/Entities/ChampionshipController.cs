using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driverRepo = new DriverRepository();
        private IRepository<IRace> raceRepo = new RaceRepository();
        private IRepository<ICar> carRepo = new CarRepository();
        public ChampionshipController()
        {
            
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepo.GetByName(driverName);
            ICar car = carRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepo.GetByName(raceName);
            IDriver driver = driverRepo.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = carRepo.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            
            if (type + "Car" == typeof(MuscleCar).Name)
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type + "Car" == typeof(SportsCar).Name)
            {
                car = new SportsCar(model, horsePower);
            }

            carRepo.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = driverRepo.GetByName(driverName);
            
            if(driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            driver = new Driver(driverName);
            driverRepo.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            IRace raceFromRepo = raceRepo.GetByName(name);

            if (race == raceFromRepo)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            raceRepo.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();

            IRace race = raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            List<IDriver> drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            IDriver firstPlace = drivers.First();
            IDriver secondPlace = drivers.Skip(1).FirstOrDefault();
            IDriver thirdPlace = drivers.Skip(2).FirstOrDefault();

            firstPlace.WinRace();

            sb.AppendLine($"Driver {firstPlace.Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {secondPlace.Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {thirdPlace.Name} is third in {race.Name} race.");

            
            raceRepo.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
