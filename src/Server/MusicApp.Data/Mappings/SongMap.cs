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
  public class SongMap : IEntityTypeConfiguration<Song>
  {
    public void Configure(EntityTypeBuilder<Song> builder)
    {
      builder.ToTable("Songs");

      builder.HasKey(s => s.Id);

      builder.Property(s => s.Name)
        .HasMaxLength(500)
        .IsRequired();

      builder.Property(s => s.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(s => s.Lyrics)
        .HasMaxLength(5000);

      builder.Property(s => s.LrcUrl)
        .HasMaxLength(1000);

      builder.Property(s => s.HasLyrics)
        .IsRequired()
        .HasDefaultValue(false);

      builder.Property(s => s.Meta)
        .HasMaxLength(5000)
        .IsRequired();

      builder.Property(s => s.SongUrl)
        .HasMaxLength(500)
        .IsRequired();

      builder.Property(s => s.ImageUrl)
        .HasMaxLength(500);

      builder.Property(s => s.TotalPlayCount)
        .IsRequired()
        .HasDefaultValue(0);

      builder.Property(s => s.TotalLike)
        .IsRequired()
        .HasDefaultValue(0);

      builder.Property(s => s.CreatedDate)
        .HasColumnType("datetime");

      builder.Property(s => s.UpdatedDate)
        .HasColumnType("datetime");

      builder.Property(s => s.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.HasOne(s => s.Category)
        .WithMany(c => c.Songs)
        .HasForeignKey(s => s.CategoryId)
        .HasConstraintName("FK_Songs_Categories")
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasMany(s => s.Tags)
        .WithMany(t => t.Songs)
        .UsingEntity(st => st.ToTable("SongTags"));

      builder.HasMany(s => s.Artists)
        .WithMany(a => a.Songs)
        .UsingEntity(sa => sa.ToTable("SongArtists"));


      builder.HasMany(s => s.Playlists)
        .WithMany(p => p.Songs)
        .UsingEntity(sp => sp.ToTable("SongPlaylists"));
    }
  }
}
