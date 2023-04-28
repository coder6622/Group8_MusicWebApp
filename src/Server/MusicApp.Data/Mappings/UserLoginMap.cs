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
  public class UserLoginMap : IEntityTypeConfiguration<UserLogin>
  {
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
      builder.ToTable("UserLogins");

      builder.HasKey(x => x.Id);
    }
  }
}
