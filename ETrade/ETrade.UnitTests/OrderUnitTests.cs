using ETrade;

namespace ETradeUnitTests
{
    [TestFixture]
    public class OrderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            var order = new Order(1, comodity, 15);
            Assert.That(order.Goods.Category, Is.EqualTo("Телевизор"));
            Assert.That(order.Goods.Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(order.Quantity, Is.EqualTo(15));
        }

        [Test]
        public void OrderCreatorTest()
        {
            var creator = new OrderCreator();

            var order = creator.Create(1, "Телевизор\tSamsung UE55TU7097U\t39990\t15");
            Assert.That(order.ID, Is.EqualTo(1));
            Assert.That(order.Goods.Category, Is.EqualTo("Телевизор"));
            Assert.That(order.Goods.Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(order.Quantity, Is.EqualTo(15));
        }
    }
}
