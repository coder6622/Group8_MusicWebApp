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
  public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
  {
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
      builder.ToTable("RoleClaims");

      builder.HasKey(x => x.Id);
    }
  }
}
