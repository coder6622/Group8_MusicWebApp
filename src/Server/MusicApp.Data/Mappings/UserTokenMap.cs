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
  public class UserTokenMap : IEntityTypeConfiguration<UserToken>
  {
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
      builder.ToTable("UserTokens");

      builder.HasKey(x => x.Id);
    }
  }
}
