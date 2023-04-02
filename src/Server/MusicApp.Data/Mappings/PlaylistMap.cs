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
  public class PlaylistMap : IEntityTypeConfiguration<Playlist>
  {
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
      builder.ToTable("Playlists");

      builder.HasKey(p => p.Id);

      builder.Property(p => p.Name)
        .HasMaxLength(500)
        .IsRequired();

      builder.Property(p => p.UrlSlug)
        .HasMaxLength(1000)
        .IsRequired();

      builder.Property(p => p.ImageUrl)
        .HasMaxLength(1000);

      builder.Property(p => p.IsPublic)
        .IsRequired()
        .HasDefaultValue(false);

      builder.Property(p => p.CreatedDate)
        .HasColumnType("datetime");

      builder.Property(p => p.UpdatedDate)
        .HasColumnType("datetime");

      builder.Property(p => p.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.HasOne(p => p.User)
        .WithMany(a => a.Playlists)
        .HasForeignKey(p => p.UserId)
        .HasConstraintName("FK_Playlists_Accounts")
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasMany(p => p.Artists)
        .WithMany(a => a.Playlists)
        .UsingEntity(pa => pa.ToTable("PlaylistArtists"));


      builder.HasMany(p => p.Tags)
        .WithMany(a => a.Playlists)
        .UsingEntity(pa => pa.ToTable("PlaylistTags"));
    }
  }
}
