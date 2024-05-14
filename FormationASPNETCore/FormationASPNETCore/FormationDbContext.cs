using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FormationASPNETCore.Configurations;
using FormationASPNETCore.Entities;

namespace FormationASPNETCore
{
    public class FormationDbContext : DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Media> Medias { get; set; }

        public FormationDbContext(DbContextOptions<FormationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PublisherConfiguration))!);
        }


    }
}
