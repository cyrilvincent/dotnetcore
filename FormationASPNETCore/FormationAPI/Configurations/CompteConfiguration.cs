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
    public class CompteConfiguration : IEntityTypeConfiguration<Compte>
    {
        public void Configure(EntityTypeBuilder<Compte> builder)
        {
            builder.ToTable("compte");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Solde).HasColumnName("solde").IsRequired();

            builder.Property(entity => entity.Devise).HasColumnName("devise").IsRequired().HasMaxLength(3);

            builder.Property(entity => entity.Commentaire).HasColumnName("commentaire").HasMaxLength(255);
        }
    }
}
