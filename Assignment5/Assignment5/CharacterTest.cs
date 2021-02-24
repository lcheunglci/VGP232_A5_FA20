using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        private Character Character;
        readonly private string Name = "Default Name";
        readonly private RaceCategory Race = RaceCategory.Human;
        readonly private int HP = 100;

        [SetUp]
        public void SetUp()
        {
            Character = new Character(Name, Race, HP);
        }


        // TakeDamage reduce the correct amount to health
        [Test]
        public void Character_TakeDamage10_Health90()
        {
            try
            {
                Character.TakeDamage(10);
                Assert.AreEqual(Character.Health, 90);
                Assert.IsTrue(Character.IsAlive);
                Assert.AreEqual(Character.MaxHealth, 100);
                Assert.AreEqual(Character.Race, Race);
            }
            catch (Exception)
            {
                Console.WriteLine("TakeDamage reduce the wrong amount to health.");
            }
        }

        // TakeDamage will set the IsAlive to false
        [Test]
        public void Character_TakeDamage200_IsAliveFalse()
        {
            try
            {
                Character.TakeDamage(200);
                Assert.AreEqual(Character.Health, 0);
                Assert.IsFalse(Character.IsAlive);
                Assert.AreEqual(Character.MaxHealth, HP);
                Assert.AreEqual(Character.Race, Race);
            }
            catch (Exception)
            {
                Console.WriteLine("TakeDamage does not set IsAlive to false");
            }
        }

        // RestoreHealth restores the correct amount to Health
        [Test]
        public void Character_RestoreHealth50()
        {
            try
            {
                Character.Health = 60;
                Character.RestoreHealth(50);
                Assert.AreEqual(Character.Health, 100);
                Assert.IsTrue(Character.IsAlive);
                Assert.AreEqual(Character.MaxHealth, HP);
                Assert.AreEqual(Character.Race, Race);
                
                Character.Health = 20;
                Character.RestoreHealth(50);
                Assert.AreEqual(Character.Health, 70);
                Assert.IsTrue(Character.IsAlive);
                Assert.AreEqual(Character.MaxHealth, HP);
                Assert.AreEqual(Character.Race, Race);
            }
            catch (Exception)
            {
                Console.WriteLine("RestoreHealth restore the wrong amount to health.");
            }
        }

        // RestoreHealth can also set the IsAlive to true if above 0.
        [Test]
        public void Character_RestoreHealth50_IsAliveTrue()
        {
            try
            {
                Character.Health = -10;
                Character.RestoreHealth(50);
                Assert.AreEqual(Character.Health, 40);
                Assert.IsTrue(Character.IsAlive);
                Assert.AreEqual(Character.MaxHealth, HP);
                Assert.AreEqual(Character.Race, Race);
            }
            catch (Exception)
            {
                Console.WriteLine("RestoreHealth fails to set IsAlive to True.");
            }
        }
    }
}
