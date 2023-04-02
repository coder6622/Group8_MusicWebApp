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
  public class RoleMap : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.ToTable("Roles");

      builder.HasKey(x => x.Id);

      builder.HasMany<UserRole>()
        .WithOne(x => x.Role)
        .HasForeignKey(x => x.RoleId)
        .IsRequired();

      builder.HasMany<RoleClaim>()
        .WithOne()
        .HasForeignKey(x => x.RoleId)
        .IsRequired();
    }
  }
}
