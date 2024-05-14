using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormationASPNETCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using FormationASPNETCore.Entities;
using FormationASPNETCore.Services;
using Microsoft.Extensions.Logging;

namespace Tests
{


    [TestFixture]
    public class MyIntegrationTests
    {
        private FormationDbContext context;
        private ILogger<MediaService> logger;

        [SetUp]
        public void SetUp()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            builder.UseNpgsql("Host=localhost;Port=5433;Database=mydb;Username=postgres;Password=mot-de-passe")
                .UseInternalServiceProvider(serviceProvider);
            this.context = new FormationDbContext(builder.Options);

            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = factory.CreateLogger<MediaService>();
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }

        [Test]
        public void FirstTest()
        {
            Assert.That(1+1==2, Is.True, "1+1==2");
        }

        [Test]
        public void SecondTest()
        {
            var p = new Publisher { Name = "Cyril" };
            Assert.That(p.Name, Is.EqualTo("Cyril"));
        }

        [Test]
        public void DbContextTest()
        {
            var publishers = context.Publishers.ToList();
            Assert.That(publishers.Count, Is.EqualTo(1));
        }


        [Test]
        public void DbContextAddTest()
        {
            var p = new Publisher { Name = "Cyril" };
            context.Publishers.Add(p);
            context.SaveChanges();
        }

        [Test]
        public void DbContextAddMediaTest()
        {
            var publisher = context.Publishers.First();
            var media = new Media { Title="C#", Price=10, MediaType=MediaType.Book };
            media.Publisher = publisher;
            context.Medias.Add(media);
            context.SaveChanges();
        }

        [Test]
        public void DbContextOneToManyTest()
        {
            var media = context.Medias.Include(e => e.Publisher).First();
            Assert.That(media.Publisher, Is.Not.Null);  
        }

        [Test]
        public void DbContextOneToManyWithManyTest()
        {
            var media = context.Medias.Include(e => e.Publisher).First();
            var medias = media.Publisher.Medias.ToList();
            Assert.That(medias.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ServiceTest()
        {
            var service = new MediaService(context, logger);
            var media = service.FilterByTitle("C").First();
            Assert.That(media, Is.Not.Null);

        }
    }
}

