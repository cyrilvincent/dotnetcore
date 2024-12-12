using FormationAPI.Entities;

namespace FormationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void FirstTest()
        {
            int i = 1 + 1;
            // Assert.AreEqual(2, i);
            Assert.That(i, Is.EqualTo(2));
        }

        [Test]
        public void TestCompte()
        {
            var c = new Compte();
            Assert.That(c.Devise, Is.EqualTo("EUR"));
        }
    }
}