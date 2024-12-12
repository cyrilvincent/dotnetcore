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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Montant).HasColumnName("montant").IsRequired();

            builder.Property(entity => entity.DateTime).HasColumnName("date_time").IsRequired();

            builder.Property(entity => entity.Type).HasColumnName("type").IsRequired();

            builder.HasOne(entity => entity.Compte)
                .WithMany(entity => entity.Transactions)
                .HasForeignKey(entity => entity.CompteId);
        }
    }
}
