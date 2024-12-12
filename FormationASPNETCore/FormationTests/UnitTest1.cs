using FormationAPI;
using FormationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Constraints;

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

        [Test]
        public void TestAddCompte()
        {
            var c = new Compte { Solde = 10 };
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False");
            var context = new FormationDbContext(builder.Options);
            context.Add(c);
            context.SaveChanges();
        }

        [Test]
        public void TestGetCompte()
        {
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False");
            var context = new FormationDbContext(builder.Options);
            var compte = context.Comptes.Where(c => c.Id == 1).First();
            Assert.That(compte, Is.Not.Null);
            Assert.That(compte.Devise, Is.EqualTo("EUR"));
        }

        [Test]
        public void TestUpdateCompte()
        {
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False");
            var context = new FormationDbContext(builder.Options);
            var compte = context.Comptes.Where(c => c.Id == 1).First();
            compte.Solde = 20;
            context.SaveChanges();
            compte = context.Comptes.Where(c => c.Id == 1).First();
            Assert.That(compte.Solde, Is.EqualTo(20));
        }

        public void TestRemoveCompte()
        {
            //var builder = new DbContextOptionsBuilder<FormationDbContext>();
            //builder.UseSqlServer("Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False");
            //var context = new FormationDbContext(builder.Options);
            //var compte = context.Comptes.Where(c => c.Id == 1).First();
            //context.Comptes.Remove(compte);
            //context.SaveChanges();
        }

        [Test]
        public void TestWhereCompte()
        {
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Formation;Integrated Security=True;Encrypt=False");
            var context = new FormationDbContext(builder.Options);
            var compte = context.Comptes.Where(c => c.Solde < 15).ToList();
            Assert.That(compte.Count, Is.EqualTo(1));

        }

        // Faire un test qui ajoute 10 comptes avec un solde qui varie de 100 à 1000
        // Faire un autre test qui filtre tous les comptes avec solde < 50 trié par solde
    }
}