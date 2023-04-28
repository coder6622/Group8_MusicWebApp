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
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.UserName)
        .HasMaxLength(100);

      builder.Property(x => x.ImageUrl)
        .HasMaxLength(1000);

      builder.Property(x => x.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

      builder.HasIndex(x => x.NormalizedUserName)
        .HasDatabaseName("IX_Accounts_NormalizedUserName")
        .IsUnique();
      builder.HasIndex(x => x.NormalizedEmail)
        .HasDatabaseName("IX_Accounts_NormalizedUserEmail")
        .IsUnique();

      builder.HasMany<UserRole>()
        .WithOne(x => x.Account)
        .HasForeignKey(x => x.UserId)
        .IsRequired();

      builder.HasMany<UserSong>()
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .IsRequired();

      builder.HasMany<UserClaim>()
        .WithOne()
        .HasForeignKey(x => x.UserId)
        .IsRequired();

      builder.HasMany<UserLogin>()
        .WithOne()
        .HasForeignKey(x => x.UserId)
        .IsRequired();

      builder.HasMany<UserToken>()
        .WithOne()
        .HasForeignKey(x => x.UserId)
        .IsRequired();
    }
  }
}
