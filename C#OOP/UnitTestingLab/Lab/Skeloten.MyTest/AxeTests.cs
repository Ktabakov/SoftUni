using NUnit.Framework;
using System;

namespace Skeloten.MyTest
{
    [TestFixture]
    public class AxeTests
    {
        private int attack = 5;
        private int durrability = 6;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durrability);
            dummy = new Dummy(5, 6);
        }

        [Test]
        public void AreAttackAndDurabilitySetCorrectly()
        {

            Assert.AreEqual(axe.AttackPoints, attack);
            Assert.AreEqual(axe.DurabilityPoints, durrability);
        }

        [Test]
        public void WhenAxeAttacksShouldLoseDurability()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, durrability - 1);
        }
        [Test]
        public void AxeAttacksWith0Durrability()
        {
            dummy = new Dummy(500, 6000);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 7; i++)
                {
                    this.axe.Attack(dummy);
                }
            });

            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}
