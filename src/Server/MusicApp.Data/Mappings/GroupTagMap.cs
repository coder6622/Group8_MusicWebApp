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
  public class GroupTagMap : IEntityTypeConfiguration<GroupTag>
  {
    public void Configure(EntityTypeBuilder<GroupTag> builder)
    {
      builder.ToTable("GroupTags");

      builder.HasKey(gt => gt.Id);

      builder.Property(gt => gt.Name)
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(gt => gt.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(gt => gt.Enable)
        .IsRequired()
        .HasDefaultValue(true);
    }
  }
}
