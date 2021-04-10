using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitDriver driver1;
        RaceEntry raceEntry = new RaceEntry();

        [SetUp]
        public void Setup()
        {
            driver = new UnitDriver("koko", new UnitCar("shkoda", 1000, 200));
            driver1 = new UnitDriver("ivo", new UnitCar("pejo", 1000, 100));
        }

        [Test]
        public void ShouldThrowWhenDriverIsNull()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
           {
               raceEntry.AddDriver(null);
           });

            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }
        [Test]
        public void ShouldThrowWhenDriverCountIsLessThanMinPartBeiCalculateAverHP()
        {
            RaceEntry raceEntry1 = new RaceEntry();

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry1.CalculateAverageHorsePower();
            });

            Assert.AreEqual(ex.Message, $"The race cannot start with less than 2 participants.");
        }
        [Test]
        public void ShouldThrowWhenDriverIsInDictionary()
        {
            RaceEntry raceEntry1 = new RaceEntry();

            UnitDriver driver2 = new UnitDriver("ivo", new UnitCar("pejo", 1000, 100));
            raceEntry1.AddDriver(driver1);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry1.AddDriver(driver2);
            });

            Assert.AreEqual(ex.Message, $"Driver {driver1.Name} is already added.");
        }
        [Test]
        public void AddedMessageShouldBeTheSame()
        {
            UnitDriver driver1 = new UnitDriver("ivo", new UnitCar("pejo", 9000, 100));

            string message = raceEntry.AddDriver(driver1);

            Assert.AreEqual(message, $"Driver {driver1.Name} added in race.");
        }
        [Test]
        public void AverHPShouldBeSame()
        {
            RaceEntry raceEntry1 = new RaceEntry();
            raceEntry1.AddDriver(driver);
            raceEntry1.AddDriver(driver1);
            double averHPShouldBeSame = raceEntry1.CalculateAverageHorsePower();

            Assert.AreEqual(averHPShouldBeSame, 1000);
        }
        [Test]
        public void CounterShouldBeSame()
        {
            RaceEntry raceEntry1 = new RaceEntry();

            UnitDriver driver1 = new UnitDriver("ivo", new UnitCar("pejo", 1000, 100));
            raceEntry1.AddDriver(driver1);

            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }
    }
}