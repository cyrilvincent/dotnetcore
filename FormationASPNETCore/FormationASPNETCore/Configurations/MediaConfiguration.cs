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
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("media");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Title).HasColumnName("title").IsRequired().HasMaxLength(255);
            builder.HasIndex(entity => entity.Title);

            builder.Property(entity => entity.Price).HasColumnName("price").IsRequired();
            builder.HasIndex(entity => entity.Price);

            builder.Property(entity => entity.MediaType).HasColumnName("type").IsRequired();

            builder.Property(entity => entity.Comment).HasColumnName("comment");

            builder.Property(entity => entity.PublisherId).HasColumnName("publisher_id");

            builder.HasOne(entity => entity.Publisher)
                   .WithMany(entity => entity.Medias)
                   .HasForeignKey(entity => entity.PublisherId);

            builder.HasMany(entity => entity.Authors).WithMany(entity => entity.Medias).UsingEntity(entity => entity.ToTable("media_author")); ;
        }
    }
}
