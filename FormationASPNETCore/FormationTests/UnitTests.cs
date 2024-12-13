using FormationAPI;
using FormationAPI.Entities;
using FormationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationTests
{
    public class UnitTests
    {

        private FormationDbContext context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<FormationDbContext>()
                       .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Installer EFInMemory
                       .Options;
            context = new FormationDbContext(options);
            context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }

        [Test]
        public void TestCompte()
        {
            var c = new Compte { Solde = 10 };
            context.Add(c);
            context.SaveChanges();
            var comptes = context.Comptes.ToList();
            Assert.That(comptes.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestIoC()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEntity, Compte>();
            var serviceProvider = services.BuildServiceProvider();
            var entity = serviceProvider.GetService<IEntity>();
            Assert.That(entity, Is.Not.Null);
            var compte = (Compte)entity;

        }

        [Test]
        public void TestDI()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEntity, Compte>();
            services.AddScoped<ITestInjection, TestInjection>();
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<ITestInjection>()!;
            Assert.That(service.Entity, Is.Not.Null);
        }

        
        // TP
        // Ajouter le package EntityFrameworkCore.InMemory
        // Ajouter dans le projet Web injection.cs depuis github
        // Comprendre Injection.cs dans le projet API
        // Comprendre dans program.cs pourquoi j'ai mis en commentaire les lignes 11 à 15 et remplacé par la ligne 16
        // Faire tourner IntegrationTests
        // Créer le répertoire Services dans API
        // Ajouter la classe TestInjection.cs comme dans Github
        // Comprendre le Setup de UnitTest et faire tourner

    }
}
