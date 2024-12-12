using FormationAPI.Configurations;
using FormationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormationAPI
{
    public class FormationDbContext : DbContext
    {
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public FormationDbContext(DbContextOptions<FormationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.HasDefaultSchema("public"); // Pour PG
            // Uniquement si l'assemblage est dans une autre DLL
            // builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CompteConfiguration))!);
        }


    }
}
