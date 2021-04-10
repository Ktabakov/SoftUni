using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void WhenDatabaseExceedesCountThrowException()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }
        [Test]
        public void WhenItemAddedIncreaseCount()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            Assert.That(database.Count, Is.EqualTo(3));
        }
        [Test]
        public void AddElementToDatabase()
        {
            int element = 123;
            database.Add(element);

            int[] elements = this.database.Fetch();
            Assert.That(elements.Contains(element));
        }
        [Test]
        public void WhenRemoveItemInEmptyDatabaseThrow()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveDecreasesDatabaseCount()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveDeletesElementFromDatabase()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            database.Remove();

            int[] elements = database.Fetch();

            Assert.That(!elements.Contains(3));
        }
        [Test]
        public void FetchReturnsDatabaseCopyInsteadOfReferance()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            int[] firstInstance = database.Fetch();
            database.Add(4);
            int[] secondInstance = database.Fetch();

            Assert.That(firstInstance, Is.Not.EqualTo(secondInstance));
        }
        [Test]
        public void CountReturnsZeroWhenDatabaseEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void CtorThrowsWhenCapacityExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database.Database(1,2,3,4,5,6,7,8,9,10,11,12,13,
                14,15,16,17));
        }
        [Test]
        public void CtorAddsElementsToDatabase()
        {
            database = new Database.Database(1, 2);
            Assert.That(database.Count, Is.EqualTo(2));
        }
    }
}