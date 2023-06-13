using System.Diagnostics;
using RandomGenerator;

namespace RandomDistributionUnitTestProject
{
    [TestFixture]
    public class RandomDistributionUnitTest
    {
        private const int seed = 123;

        [Test]
        public void GiveUniqueResultsOnEveryGenerateRun()
        {
            var rnd = new Random(seed);
            var generator = new Generator<T1>();
            var e1 = generator.Generate(rnd);
            var e2 = generator.Generate(rnd);
            Assert.AreNotSame(e1, e2);
            Assert.AreNotEqual(e1.A, e2.A);
        }

        [Test]
        public void GenerateT1()
        {
            var rnd = new Random(seed);
            var e = new Generator<T1>().Generate(rnd);
            AssertPropertyFilledWithDistribution(e.A, new NormalDistribution(1, 2));
        }

        [Test]
        public void GenerateT2()
        {
            var rnd = new Random(seed);
            var e = new Generator<T2>().Generate(rnd);
            AssertPropertyFilledWithDistribution(e.A, new NormalDistribution(-1, 2));
            Assert.AreEqual(42.0, e.B, 1e-8, "Свойство без атрибута изменять нельзя");
            Assert.AreEqual(0.0, e.C, 1e-8, "Свойство без атрибута изменять нельзя");
            AssertPropertyFilledWithDistribution(e.D, new NormalDistribution(0, 1));
        }

        [Test]
        public void PerformanceTest()
        {
            var rnd = new Random(seed);
            var g = new Generator<T2>();

            g.Generate(rnd);

            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 100000; i++)
            {
                g.Generate(rnd);
            }

            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 2000, $"Elapsed {sw.ElapsedMilliseconds} ms");
        }

        [Test]
        public void ExceptionTest()
        {
            var rnd = new Random(seed);
            var g = new Generator<T3>();
            Assert.Throws<ArgumentException>(() => g.Generate(rnd));
        }

        private void AssertPropertyFilledWithDistribution(double actualValue, NormalDistribution distribution)
        {
            var rnd = new Random(seed);
            var sequenceStart = new[] { distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd) };
            rnd = new Random(seed);
            rnd.NextDouble();
            var sequence = sequenceStart.Concat(new[] { distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd), distribution.Generate(rnd) }).ToArray();
            CollectionAssert.Contains(sequence, actualValue);
        }
    }
}
