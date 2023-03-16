
namespace FractionLib.UnitTests
{
    [TestFixture]
    public class FractionTests
    {
        Fraction f;

        [SetUp]
        public void Setup()
        {
            f = new Fraction(-2, 3);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(f.Numerator, Is.EqualTo(-2));
            Assert.That(f.Denominator, Is.EqualTo(3));
        }

        [Test]
        public void ToStringTest()
        {
            Assert.That(f.ToString(), Is.EqualTo("-2/3"));
        }

        [TestCase(1, 2, 2, 4, true)]
        [TestCase(1, 2, 2, 3, false)]
        public void Equals_ToFractions_Result(
            int numerator1, int deniminator1,
            int numerator2, int denominator2,
            bool result)
        {
            var a = new Fraction(numerator1, deniminator1);
            var b = new Fraction(numerator2, denominator2);

            Assert.That(a.Equals(b), Is.EqualTo(result));
        }

        [Test]
        public void Equals_ToObject_ArgumentException()
        {
            var obj = new object();

            Assert.That(() => f.Equals(obj), Throws.ArgumentException);
        }
    }
}