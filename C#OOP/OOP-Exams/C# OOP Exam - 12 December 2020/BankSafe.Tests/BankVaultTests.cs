using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");
        }

        [Test]
        public void ShouldThrowWhenCellDoesntExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("doesnt exist", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellTakenShouldThrow()
        {
            vault.AddItem("A1", item);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", new Item("koko", "12"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }
        [Test]
        public void ShouldThrowWhenItemIsALreadyInCell()
        {
            vault.AddItem("A1", item);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("B1", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void ResultShouldBeSame()
        {
            string result = vault.AddItem("A1", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void ShouldThrowWhenCellDoesntExistWithRemove()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("doesnt exist", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void ShouldThrowWhenRemovingNonExistingItem()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A1", new Item("pesho", "3"));
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }
        [Test]
        public void ShouldReturnRightMessageWhenRemove()
        {
            vault.AddItem("A1", item);
            vault.AddItem("A2", new Item("koko", "2"));

            string result = vault.RemoveItem("A1", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }

    }
}