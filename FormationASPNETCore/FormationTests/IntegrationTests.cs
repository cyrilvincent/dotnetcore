using FormationAPI;
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
    public class IntegrationTests
    {

        private FormationDbContext context;
        private ServiceProvider serviceProvider;

        [SetUp]
        public void SetUp()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            Injections.InjectDbContext(services, configuration.GetConnectionString("FormationDb")!);
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            serviceProvider = services.AddEntityFrameworkSqlServer().BuildServiceProvider();
            builder.UseSqlServer(configuration.GetConnectionString("FormationDb")).UseInternalServiceProvider(serviceProvider);
            this.context = new FormationDbContext(builder.Options);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
            this.serviceProvider.Dispose();
        }

        [Test]
        public void TestCompte()
        {
            var compte = context.Comptes.Where(c => c.Id == 1).First();
            Assert.That(compte, Is.Not.Null);
        }
    }
}
