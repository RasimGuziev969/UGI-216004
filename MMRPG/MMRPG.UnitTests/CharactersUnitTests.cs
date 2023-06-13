using MMRPG;

namespace MMRPGUnitTestProject
{
    [TestFixture]
    public class CharactersUnitTests
    {
        [Test]
        public void HumanTest()
        {
            var hero = new CharacterCreator(new HumanFactory()).Create("Арагорн");
            Assert.That(hero, Is.TypeOf(typeof(Human)));
            Assert.AreEqual("Арагорн", hero.Name);
            Assert.AreEqual(40, hero.Health);
            Assert.AreEqual(30, hero.Strength);
            Assert.AreEqual(30, hero.Dexterity);
            Assert.That(hero.Armor, Is.TypeOf(typeof(SteelArmor)));
        }

        [Test]
        public void DwarfTest()
        {
            var hero = new CharacterCreator(new DwarfFactory()).Create("Торин");
            Assert.That(hero, Is.TypeOf(typeof(Dwarf)));
            Assert.AreEqual("Торин", hero.Name);
            Assert.AreEqual(40, hero.Health);
            Assert.AreEqual(40, hero.Strength);
            Assert.AreEqual(20, hero.Dexterity);
            Assert.That(hero.Armor, Is.TypeOf(typeof(ChainArmor)));
        }

        [Test]
        public void ElfTest()
        {
            var hero = new CharacterCreator(new ElfFactory()).Create("Элронд");
            Assert.That(hero, Is.TypeOf(typeof(Elf)));
            Assert.AreEqual("Элронд", hero.Name);
            Assert.AreEqual(20, hero.Health);
            Assert.AreEqual(30, hero.Strength);
            Assert.AreEqual(50, hero.Dexterity);
            Assert.That(hero.Armor, Is.TypeOf(typeof(LeatherArmor)));
        }

        [Test]
        public void OrcTest()
        {
            var hero = new CharacterCreator(new OrcFactory()).Create("Шаграт");
            Assert.That(hero, Is.TypeOf(typeof(Orc)));
            Assert.AreEqual("Шаграт", hero.Name);
            Assert.AreEqual(50, hero.Health);
            Assert.AreEqual(40, hero.Strength);
            Assert.AreEqual(10, hero.Dexterity);
            Assert.That(hero.Armor, Is.TypeOf(typeof(Clothes)));
        }
    }
}
