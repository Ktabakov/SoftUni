using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warr;
            
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warr = new Warrior("Alkor", 100, 100);
        }
        [Test]
        public void CtorInitializeWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void CountIsZeroWhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.Zero);
        }
        [Test]
        public void WhenWarriorExistsShouldThrow()
        {
            arena.Enroll(warr);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warr));
        }
        [Test]
        public void WhenEnrollCountShouldIncrease()
        {
            arena.Enroll(warr);
            Assert.That(arena.Count, Is.EqualTo(1));
        }
        [Test]
        public void WhenEnrollWarrShouldBeInArena()
        {
            arena.Enroll(warr);
            Assert.That(arena.Warriors.Contains(warr));
        }
        [Test]
        public void ThrowsWhenDeffenderDoesNotExist()
        {
            warr = new Warrior("Alkor", 100, 120);
            arena.Enroll(warr);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Alkor", "Koko"));
        }
        [Test]
        public void ThrowsWhenAttackerDoesNotExist()
        {
            warr = new Warrior("Alkor", 100, 120);
            arena.Enroll(warr);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Koko", "Alkor"));
        }
        [Test]
        public void ThrowsBothDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Koko", "Ivo"));
        }
        [Test]
        public void WhenFightMethodWarrsShouldLoseHealth()
        {
            warr = new Warrior("Alkor", 100, 120);
            Warrior dummy = new Warrior("Dummy", 90, 110);
            arena.Enroll(warr);
            arena.Enroll(dummy);
            arena.Fight("Alkor", "Dummy");

            Assert.That(dummy.HP, Is.EqualTo(10));
            Assert.That(warr.HP, Is.EqualTo(30));
        }
    }
}
