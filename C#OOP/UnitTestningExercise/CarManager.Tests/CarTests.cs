
using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -50)]
        public void CtorThrowsWhenInvalidData(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void CtorSetsValues_WhenValuesCorrect()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelCarWithNegativeOr0FuelShouldThrow(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }
        [Test]
        [TestCase(30)]
        public void WhenRefuelIncreaseFuelAmount(double fuel)
        {
            car.Refuel(car.FuelCapacity/2);
        }
        [Test]
        [TestCase(1000)]
        public void WhenCapacityIsFullFuelIsCapacity(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }
        [Test]
        public void WhenCarDrivesWith0FuelShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(1));
        }
        [Test]
        public void WhenValidDistance_DriveDecreasesFuelAmount()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }
        
    }
}