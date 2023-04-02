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
  public class UserSongMap : IEntityTypeConfiguration<UserSong>
  {
    public void Configure(EntityTypeBuilder<UserSong> builder)
    {
      builder.ToTable("UserSongs");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.IsLike)
        .IsRequired()
        .HasDefaultValue(false);

      builder.Property(x => x.PlayCount)
        .IsRequired()
        .HasDefaultValue(0);

      builder.Property(x => x.CreatedDate)
        .HasColumnType("datetime");

      builder.HasOne(x => x.Song)
        .WithMany(x => x.UserSongs)
        .HasForeignKey(x => x.SongId)
        .HasConstraintName("FK_AcountSongs_Songs");


      builder.HasOne(x => x.User)
        .WithMany(x => x.UserSongs)
        .HasForeignKey(x => x.UserId)
        .HasConstraintName("FK_AcountSongs_Accounts");
    }
  }
}
