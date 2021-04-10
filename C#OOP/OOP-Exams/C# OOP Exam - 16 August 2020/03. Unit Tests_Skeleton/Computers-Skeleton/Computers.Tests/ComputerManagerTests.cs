using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }


        [Test]
        public void ValidateNullValueShouldThrowWhenPerformer()
        {
            Computer computer = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.AddComputer(computer);
            });

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'computer')");

        }

        [Test]
        public void ThrowIfComputerExist()
        {
            Computer computer1 = new Computer("ivano", "koko100is", 20000);
            this.computerManager.AddComputer(computer1);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.AddComputer(computer1);
            });

            Assert.AreEqual(ex.Message, "This computer already exists.");
        }
        [Test]
        public void CountShoudBeCorrect()
        {
            Computer computer1 = new Computer("ivano", "koko100is", 20000);
            this.computerManager.AddComputer(computer1);

           
            Assert.That(this.computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldThrowIfAnythingIsNullPrivateMethod()
        {
            Computer computer1 = new Computer(null, "koko100is", 20000);
            this.computerManager.AddComputer(computer1);

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputer(null, "koko100is");
            });

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'manufacturer')");
        }
        [Test]
        public void ShouldThrowWhenNameIsNull()
        {
            Computer computer1 = new Computer("koko", null, 20000);
            this.computerManager.AddComputer(computer1);

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputer("koko", null);
            });

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'model')");
        }
        [Test]
        public void CountIncreaseWhenAdd()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            this.computerManager.AddComputer(computer);

            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
        }
        [Test]
        public void CountShouldDecreaseWhenRemove()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            Computer computer1 = new Computer("ivano", "koko100is", 20000);
            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(computer1);

            this.computerManager.RemoveComputer("ivano", "koko100is");
            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
        }
        [Test]
        public void PropCountShouldDecreaseWhenRemove()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            Computer computer1 = new Computer("ivano", "koko100is", 20000);
            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(computer1);

            this.computerManager.RemoveComputer("ivano", "koko100is");
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThrowIfNoSuchCOmputerExistInSystemWhenGetComputer()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            this.computerManager.AddComputer(computer);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.GetComputer("koko", null);
            });

            Assert.AreEqual(ex.Message, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldReturnTheRightComputer()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            this.computerManager.AddComputer(computer);

            Computer pc = this.computerManager.GetComputer("koko", "koko100");

            Assert.AreEqual(computer, pc);
        }
        [Test]
        public void RemoveComputerShouldReturnCorrectComputer()
        {
            Computer computer = new Computer("koko", "koko100", 2000);
            this.computerManager.AddComputer(computer);
            Computer pc = this.computerManager.RemoveComputer("koko", "koko100");

            Assert.AreEqual(computer, pc);
        }
        [Test]
        public void GetComputersByManufacturerShouldReturnCorrect()
        {
            Computer computer = new Computer("koko100", "koko0", 2000);
            Computer computer1 = new Computer("koko100", "kokinio", 2000);

            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(computer1);

            ICollection<Computer> myComputers = new List<Computer>();
            myComputers.Add(computer);
            myComputers.Add(computer1);

            ICollection<Computer> computers = this.computerManager.GetComputersByManufacturer("koko100");


            Assert.AreEqual(computers, myComputers);
        }
    }
}