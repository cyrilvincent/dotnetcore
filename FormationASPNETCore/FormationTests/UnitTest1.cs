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
        private FormationDbContext Context { get; set; }

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            var connectionString = configuration.GetConnectionString("FormationDb");
            builder.UseSqlServer(connectionString);
            Context = new FormationDbContext(builder.Options);
        }

        [TearDown]
        public void TearDown()
        {
            Context.Dispose();
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
            Context.Add(c);
            Context.SaveChanges();
        }

        [Test]
        public void TestGetCompte()
        {
            var compte = Context.Comptes.Where(c => c.Id == 1).First();
            Assert.That(compte, Is.Not.Null);
            Assert.That(compte.Devise, Is.EqualTo("EUR"));
        }

        [Test]
        public void TestUpdateCompte()
        {
            var compte = Context.Comptes.Where(c => c.Id == 1).First();
            compte.Solde = 20;
            Context.SaveChanges();
            compte = Context.Comptes.Where(c => c.Id == 1).First();
            Assert.That(compte.Solde, Is.EqualTo(20));
        }

        public void TestRemoveCompte()
        {
            //var compte = Context.Comptes.Where(c => c.Id == 1).First();
            //Context.Comptes.Remove(compte);
            //Context.SaveChanges();
        }

        [Test]
        public void TestWhereCompte()
        {
            var compte = Context.Comptes.Where(c => c.Solde > 15).ToList();
            Assert.That(compte.Count, Is.GreaterThan(0));
        }

        [Test]
        public void TestCreateComptes()
        {
            for (int i = 0; i < 10; i++)
            {
                var c = new Compte { Solde = i * 100 };
                Context.Comptes.Add(c);
            }
            Context.SaveChanges();
        }

        [Test]
        public void TestSoldeCompte()
        {
            var comptes = Context.Comptes.Where(c => c.Solde < 50).OrderBy(c => c.Solde).ToList();
            Assert.That(comptes.Count, Is.GreaterThan(0));
        }

        // Faire un test qui ajoute 10 comptes avec un solde qui varie de 100 à 1000
        // Faire un autre test qui filtre tous les comptes avec solde < 50 trié par solde

        [Test]
        public void TestTransactions()
        {
            var compte = Context.Comptes.Where(c => c.Id == 1).First();
            var transaction = new Transaction { Compte = compte, Montant = 10m, Type = TransactionType.Credit };
            // Context.Transactions.Add(transaction);
            compte.Transactions.Add(transaction);
            Context.SaveChanges();
        }

        [Test]
        public void TestMultipleTransactions()
        {
            var compte = Context.Comptes.Where(c => c.Id == 1).First();
            for (int i = 0; i < 10; i++)
            {
                var t = new Transaction { Compte = compte, Montant = (i + 1) * 100, Type = TransactionType.Credit };
                compte.Transactions.Add(t);
            }
            Context.SaveChanges();
        }

        [Test]
        public void TestJoinTransactions()
        {
            var compte = Context.Comptes.Include(c => c.Transactions).Where(c => c.Id == 1).First();
            var t = compte.Transactions.Where(t => t.Montant < 200);
            Assert.That(compte.Transactions.ToList(), Is.Not.Null);

            
        }

        // Créer 2 clients
        // Associer un compte à 2 clients
        // Associer 1 client à 2 comptes

    }
}