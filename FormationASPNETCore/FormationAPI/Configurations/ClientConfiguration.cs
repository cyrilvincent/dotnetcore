using FormationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationAPI.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Nom).HasColumnName("nom").IsRequired();

            builder.Property(entity => entity.Prenom).HasColumnName("prenom");

        }
    }
}
