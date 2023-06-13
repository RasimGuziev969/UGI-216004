using DataStructure;

namespace DataStructureUnitTests
{
    [TestFixture]
    public class DataStructureUnitTests
    {
        static Category a11 = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);
        static Category a21 = new Category("A", MessageType.Outgoing, MessageTopic.Subscribe);
        static Category a12 = new Category("A", MessageType.Incoming, MessageTopic.Error);
        static Category b11 = new Category("B", MessageType.Incoming, MessageTopic.Subscribe);
        static Category a11Copy = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);
        static Category[] a = new[] { a11, a12, a21, b11 };

        [Test]
        public void ImplementFieldsCorrectly()
        {
            var fieldsInfo = typeof(Category).GetFields();
            Assert.That(fieldsInfo.Count(), Is.EqualTo(3));
            Assert.That(fieldsInfo.All(f => f.IsPublic && !f.IsStatic && f.IsInitOnly), Is.True);
        }
        
        [Test]
        public void ImplementEqualsCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.That(i == j, Is.EqualTo(a[i].Equals(a[j])), $"Error on {i} {j}");
            Assert.IsTrue(a11.Equals(a11Copy));
        }

        [Test]
        public void ImplementGetHashCodeCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (i != j)
                    {
                        // Нужно сделать так, чтобы разные объекты
                        // возвращали разные значений хеш-функций.

                        Assert.That(a[j].GetHashCode(), Is.Not.EqualTo(a[i].GetHashCode()), $"Error on {i} {j}");
                    }

            Assert.IsTrue(a11.Equals(a11Copy));
        }

        [Test]
        public void ImplementCompareToCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.That(Math.Sign(a[i].CompareTo(a[j])), Is.EqualTo(Math.Sign(i.CompareTo(j))), $"Error on {i} {j}");
            
            Assert.That(a11.CompareTo(a11Copy), Is.EqualTo(0));
        }

        [Test]
        public void ImplementOperatorsCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                {
                    Assert.That(a[i] <= a[j], Is.EqualTo(i <= j), $"Error on <=, {i} {j}");
                    Assert.That(a[i] >= a[j], Is.EqualTo(i >= j), $"Error on >=, {i} {j}");
                    Assert.That(a[i] < a[j], Is.EqualTo(i < j), $"Error on <, {i} {j}");
                    Assert.That(a[i] > a[j], Is.EqualTo(i > j), $"Error on >, {i} {j}");
                    Assert.That(a[i] == a[j], Is.EqualTo(i == j), $"Error on ==, {i} {j}");
                    Assert.That(a[i] != a[j], Is.EqualTo(i != j), $"Error on !=, {i} {j}");
                }
        }

        [Test]
        public void ImplementIComparableInterface()
        {
            Assert.IsTrue(a11 is IComparable);
        }

        [Test]
        public void ImplementToStringCorrectly()
        {
            Assert.That(a11.ToString(), Is.EqualTo("A.Incoming.Subscribe"));
        }
    }
}
