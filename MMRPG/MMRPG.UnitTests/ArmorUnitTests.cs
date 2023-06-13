using MMRPG;

namespace MMRPGUnitTestProject
{
    [TestFixture]
    public class ArmorUnitTests
    {
        [Test]
        public void ChainArmorTestMethod()
        {
            var chainArmor = new ChainArmor();
            Assert.That(chainArmor.Defense, Is.EqualTo(20));
            Assert.That(chainArmor.Durability, Is.EqualTo(40));
        }

        [Test]
        public void ClothesTestMethod()
        {
            var clothes = new Clothes();
            Assert.That(clothes.Defense, Is.EqualTo(5));
            Assert.That(clothes.Durability, Is.EqualTo(10));
        }

        [Test]
        public void LeatherArmorTestMethod()
        {
            var leatherArmor = new LeatherArmor();
            Assert.That(leatherArmor.Defense, Is.EqualTo(10));
            Assert.That(leatherArmor.Durability, Is.EqualTo(15));
        }

        [Test]
        public void SteelArmor()
        {
            var steelArmor = new SteelArmor();
            Assert.That(steelArmor.Defense, Is.EqualTo(40));
            Assert.That(steelArmor.Durability, Is.EqualTo(25));
        }
    }
}
