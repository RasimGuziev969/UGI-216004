using MapObjects;

namespace MapObjectsTests
{
    [TestFixture]
    public class MapObjectsUnitTests
    {
        [Test]
        public void TakeResources()
        {
            var player = new Player();
            Interaction.Make(player, new ResourcePile { Treasure = new Treasure { Amount = 10 } });
            Assert.That(player.Dead, Is.False);
            Assert.That(player.Gold, Is.EqualTo(10));
        }

        [Test]
        public void BeatWeakCreepsAndCollectTreasure()
        {
            var player = new Player();
            Interaction.Make(player, new Creeps { Treasure = new Treasure { Amount = 10 }, Army = new Army { Power = 1 } });
            Assert.That(player.Dead, Is.False);
            Assert.That(player.Gold, Is.EqualTo(10));
        }

        [Test]
        public void LoseToPowerfulCreeps()
        {
            var player = new Player();
            Interaction.Make(player, new Creeps { Treasure = new Treasure { Amount = 10 }, Army = new Army { Power = 10 } });
            Assert.That(player.Dead, Is.True);
            Assert.That(player.Gold, Is.EqualTo(0));
        }

        [Test]
        public void OwnDwelling()
        {
            var player = new Player { Id = 1 };
            var dwelling = new Dwelling();
            Interaction.Make(player, dwelling);
            Assert.That(player.Dead, Is.False);
            Assert.That(dwelling.Owner, Is.EqualTo(player.Id));
            Assert.That(player.Gold, Is.EqualTo(0));
        }

        [Test]
        public void BeatWeakGuardAndOwnMine()
        {
            var player = new Player { Id = 1 };
            var mine = new Mine
            {
                Army = new Army { Power = 1 },
                Treasure = new Treasure { Amount = 2 },
            };
            Interaction.Make(player, mine);
            Assert.That(player.Dead, Is.False);
            Assert.That(mine.Owner, Is.EqualTo(player.Id));
            Assert.That(player.Gold, Is.EqualTo(2));
        }

        [Test]
        public void LoseToPowerfulGuard()
        {
            var player = new Player { Id = 1 };
            var mine = new Mine
            {
                Army = new Army { Power = 10 },
                Treasure = new Treasure { Amount = 2 },
            };
            Interaction.Make(player, mine);
            Assert.That(player.Dead, Is.True);
            Assert.That(mine.Owner, Is.EqualTo(0));
            Assert.That(player.Gold, Is.EqualTo(0));
        }
    }
}
