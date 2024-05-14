using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormationASPNETCore.Entities;

namespace FormationASPNETCore.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publisher");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
            builder.HasIndex(entity => entity.Name);

            builder.Property(entity => entity.Description).HasColumnName("description").HasMaxLength(255);
        }
    }
}
