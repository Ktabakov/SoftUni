using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeloten.MyTest
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int health = 5;
        private int experience = 10;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(-5, experience);
        }
        [Test]
        public void whenHealthIsProvidedShouldSetCorrectly()
        {
            Assert.That(dummy.Health, Is.EqualTo(health));
        }
        [Test]
        public void WhenAttacked_ShouldDecreaseHealth()
        {
            int attackPoints = 3;
            dummy.TakeAttack(3);

            Assert.That(dummy.Health, Is.EqualTo(health - attackPoints));
        }
        [Test]
        public void WhenHealthPositiveDummyShouldBeAlive()
        {
            Assert.That(dummy.IsDead, Is.EqualTo(false));
        }
        [Test]
        public void WhenHealthZeroDummyShouldBeAlive()
        {
            Assert.That(deadDummy.IsDead, Is.EqualTo(true));
        }
        [Test]
        public void WhenHealthNegativeDummyShouldBeAlive()
        {
            Assert.That(deadDummy.IsDead, Is.EqualTo(true));
        }
        [Test]
        public void When_AttackedDummyIsDeadShouldThrow()
        {
            Assert.That(() =>
            {
                deadDummy.TakeAttack(10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void WhenDeadShouldGiveXP()
        {
            Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
        }
        [Test]
        public void WhenAliveGiveXPShouldThrow()
        {
            Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
        
    }
}
