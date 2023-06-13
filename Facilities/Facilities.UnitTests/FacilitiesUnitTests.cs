using Facilities;

namespace FacilitiesUnitTestProject
{
    [TestFixture]
    public class FacilitiesUnitTests
    {
        [Test]
        public void ClientTest()
        {
            var client = new Client();

            Assert.That(client.DoCalls(), Is.EqualTo(34));
        }
    }
}
