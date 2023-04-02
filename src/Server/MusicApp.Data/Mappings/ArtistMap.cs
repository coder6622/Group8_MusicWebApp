using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Mappings
{
  public class ArtistMap : IEntityTypeConfiguration<Artist>
  {
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
      builder.ToTable("Artists");

      builder.HasKey(a => a.Id);

      builder.Property(a => a.FullName)
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(a => a.ImageUrl)
        .HasMaxLength(1000);

      builder.Property(a => a.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(a => a.DayOfBirth)
        .HasColumnType("datetime");

      builder.Property(a => a.Gender)
        .IsRequired();

      builder.Property(a => a.Nation)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(a => a.Information)
        .HasMaxLength(5000);

      builder.Property(a => a.Enable)
        .IsRequired()
        .HasDefaultValue(true);
    }
  }
}
