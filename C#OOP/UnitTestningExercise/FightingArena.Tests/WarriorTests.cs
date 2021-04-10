using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warr;
        [SetUp]
        public void Setup()
        {
            warr = new Warrior("Alkor", 100, 100);
        }

        [Test] 
        [TestCase("", 100, 100)]
        [TestCase(" ", 100, 100)]
        [TestCase(null, 100, 100)]
        [TestCase("Warr", -10, 100)]
        [TestCase("Warr", 0, 100)]
        [TestCase("Warr", 100, -10)]
        public void CtorThrowsWhenInvalidData(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => warr = new Warrior(name, damage, hp));
        }
        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void AttackMehtodThrowsWhenLessThanMinAttackHP(int HPAttacker, int HPDeffender)
        {
            warr = new Warrior("Alkor", 100, HPAttacker);
            Warrior dummy = new Warrior("Dummy", 100, HPDeffender);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(dummy));
        }
        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void AttackMehtodThrowsWhenDummyHasLesThanAttackHP(int hp)
        {
            warr = new Warrior("Alkor", 100, 100);
            Warrior dummy = new Warrior("Dummy", 100, hp);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(dummy));
        }
        [Test]
        [TestCase(40)]
        public void AttackMethodThrows_WhenWarrAttacksWithLesHPThanDummyAP(int hp)
        {
            warr = new Warrior("Alkor", 100, hp);
            Warrior dummy = new Warrior("Dummy", 100, 100);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(dummy));
        }
        [Test]
        public void ReduceHPWhenAttacked()
        {
            int APDummyy = 90;
            int HPWarr = 100;
            warr = new Warrior("Alkor", 110, HPWarr);
            Warrior dummy = new Warrior("Dummy", APDummyy, 100);
            warr.Attack(dummy);

            Assert.That(warr.HP, Is.EqualTo(HPWarr - APDummyy));
            Assert.That(dummy.HP, Is.EqualTo(0));
        }
        [Test]
        public void WhenWarrAPIsGreaterThanDummyHP_SetDummyHPToZero()
        {
            int APWarr = 100;
            int HPDummy = 90;
            warr = new Warrior("Alkor", APWarr, 120);
            Warrior dummy = new Warrior("Dummy", 90, HPDummy);
            warr.Attack(dummy);

            Assert.That(dummy.HP, Is.EqualTo(0));
        }
        [Test]
        public void WarriorHPReducesAfterAttack()
        {
            int APWarr = 100;
            int HPDummy = 120;
            warr = new Warrior("Alkor", APWarr, 120);
            Warrior dummy = new Warrior("Dummy", 90, HPDummy);
            warr.Attack(dummy);

            Assert.That(dummy.HP, Is.EqualTo(HPDummy - APWarr));
        }
       
    }
}