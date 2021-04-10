using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [SetUp]
    public void TestInit()
    {
       
    }

    [Test]
    public void AreAttackAndDurabilitySetCorrectly()
    {
        int attack = 5;
        int durrability = 6;
        Axe axe = new Axe(attack, durrability);

        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durrability);
    }
    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
       
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
       
    }
}