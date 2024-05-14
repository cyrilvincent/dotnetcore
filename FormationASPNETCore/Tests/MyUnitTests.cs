using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using FormationASPNETCore.Entities;
using Moq;
using FormationASPNETCore;

namespace Tests
{


    [TestFixture]
    public class MyUnitTests
    {
        private FormationDbContext context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<FormationDbContext>()
                       .UseInMemoryDatabase(Guid.NewGuid().ToString())
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
        public void DbContextAddTest()
        {
            var p = new Publisher { Name = "Cyril" };
            context.Publishers.Add(p);
            context.SaveChanges();
            var publishers = context.Publishers.ToList();
            Assert.That(publishers.Count, Is.EqualTo(1));
        }
    }
}

