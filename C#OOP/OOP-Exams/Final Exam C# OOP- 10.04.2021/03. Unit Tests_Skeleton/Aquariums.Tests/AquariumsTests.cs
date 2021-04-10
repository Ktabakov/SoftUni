namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class AquariumsTests
    {
        Aquarium aquarium = null;
        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("koko", 6);
        }

        [Test]
        public void ShouldThrowWhenNameIsIncorrect()
        {
            Aquarium aquaOne = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                aquaOne = new Aquarium(null, 20);
            });

            Assert.AreEqual(ex.Message, "Invalid aquarium name! (Parameter 'value')");
        }

        [Test]
        public void NameSetsCorrectly()
        {
            Aquarium aquaOne = new Aquarium("koko", 20);

            Assert.AreEqual(aquaOne.Name, "koko");
        }
        [Test]
        public void ShouldThrowWhenCapacityIsFalse()
        {
            Aquarium aquaOne = null;

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                aquaOne = new Aquarium("ivan", -2);
            });

            Assert.AreEqual(ex.Message, "Invalid aquarium capacity!");
        }

        [Test]
        public void PropCapacityShouldSetCorrectly()
        {
            Aquarium aquaOne = new Aquarium("ivan", 5);

            Assert.AreEqual(aquaOne.Capacity, 5);
        }

        [Test]
        public void CountShouldBeSet()
        {
            Aquarium aquaOne = new Aquarium("ivan", 5);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Assert.AreEqual(aquaOne.Count, 2);
        }

        [Test]
        public void ShouldThrowWhenFullCapacity()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquaOne.Add(new Fish("pesho"));
            });

            Assert.AreEqual(ex.Message, "Aquarium is full!");
        }
        //maybe see if count increases when add
        [Test]
        public void ShouldRemoveCorrect()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquaOne.RemoveFish(null);
            });

            Assert.AreEqual(ex.Message, $"Fish with the name  doesn't exist!");
        }
        [Test]
        public void WhenRemoveCountChange()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            aquaOne.RemoveFish("joro");

            Assert.AreEqual(aquaOne.Count, 1);
        }
        [Test]
        public void SellFishShouldThrowWhenFishNull()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquaOne.SellFish(null);
            });

            Assert.AreEqual(ex.Message, $"Fish with the name  doesn't exist!");
        }
        [Test]
        public void WhenSellFishAndFishIsFishReqeuestShouldReturnFalse()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Fish joro = aquaOne.SellFish("joro");
            aquaOne.SellFish("joro");

            Assert.AreEqual(joro.Available, false );
        }
        [Test]
        public void SellFishShouldReturnCorrectFish()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Fish joro = aquaOne.SellFish("joro");
            aquaOne.SellFish("joro");

            Assert.AreEqual(aquaOne.SellFish("joro"), joro);
        }
        [Test]
        public void ReportShouldReturnCorect()
        {
            Aquarium aquaOne = new Aquarium("ivan", 2);
            aquaOne.Add(new Fish("joro"));
            aquaOne.Add(new Fish("misho"));

            Assert.AreEqual(aquaOne.Report(), $"Fish available at {aquaOne.Name}: joro, misho");
        }
    }
}
