using NUnit.Framework;
using System;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private Person person;
        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
            person = new Person(1, "koko");
        }

        [Test]
        public void ThrowsWhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, "16")));
        }
        [Test]
        public void ThrowsWhenPersonWithSameUsernameExist()
        {
            extendedDatabase.Add(new Person(1, "test"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(2, "test")));
        }
        [Test]
        public void ThrowsWhenPersonWithSameIDExist()
        {
            extendedDatabase.Add(new Person(1, "test"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(1, "koko")));
        }
        [Test]
        public void AddElementToDatabase()
        {
            extendedDatabase.Add(person);

            Person testPerson = this.extendedDatabase.FindById(1);
            Assert.That(person,Is.EqualTo(testPerson));
        }
        [Test]
        public void AssertThatCountIncreasesWhenPersonAdded()
        {
            extendedDatabase.Add(person);

            Assert.That(extendedDatabase.Count, Is.EqualTo(1));
        }
        [Test]
        public void ThrowsWhenRemoveFromEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }
        [Test]
        public void WhenRemovesCountGoesDown()
        {
            extendedDatabase.Add(person);
            extendedDatabase.Add(new Person(2, "joro"));

            extendedDatabase.Remove();

            Assert.That(extendedDatabase.Count, Is.EqualTo(1));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void WhenFindByUsernameReturnsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(username));
        }
        [Test]
        public void WhenFindByUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("Username"));
        }
        [Test]
        public void WhenFindBYUserNameSuccessfullReturnPerson()
        {
            extendedDatabase.Add(person);

            Person dbPerson = extendedDatabase.FindByUsername(person.UserName);

            Assert.That(dbPerson, Is.EqualTo(person));
        }
        [Test]
        public void ThrowWhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1));
        }
        [Test]
        public void ThrowWhenIDDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(10));
        }
        [Test]
        public void WhenFindByIDShouldReturnCorrectUser()
        {
            extendedDatabase.Add(person);
            Person dbPerson = extendedDatabase.FindById(1);

            Assert.That(dbPerson, Is.EqualTo(dbPerson));
        }
        [Test]
        public void CtorThrowsWhenCapacityExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase.ExtendedDatabase(arguments));
        }
        [Test]
        public void CtorAddsPeopleToDatabase()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(arguments);
            Assert.That(extendedDatabase.Count, Is.EqualTo(arguments.Length));

            foreach (var item in arguments)
            {
                Person dbPerson = this.extendedDatabase.FindById(item.Id);
                Assert.That(item, Is.EqualTo(dbPerson));
            }
        }
    }
}