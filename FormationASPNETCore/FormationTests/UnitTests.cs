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
        public void TestInjection()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEntity, Compte>();
            var serviceProvider = services.BuildServiceProvider();
            var entity = serviceProvider.GetService<IEntity>();
            Assert.That(entity, Is.Not.Null);
        }

        [Test]
        public void TestIoD()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEntity, Compte>();
            services.AddScoped<ITestInjection, TestInjection>();
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<ITestInjection>()!;
            Assert.That(service.Entity, Is.Not.Null);
        }
    }
}
