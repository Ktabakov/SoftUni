using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;
using System;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(t => t.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(20);

        Hero hero = new Hero("Koko", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}