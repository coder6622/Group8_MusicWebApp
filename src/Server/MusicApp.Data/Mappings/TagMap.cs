using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Core.Contracts;
using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Mappings
{
  public class TagMap : IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder.ToTable("Tags");

      builder.HasKey(t => t.Id);

      builder.Property(t => t.Name)
        .HasMaxLength(256)
        .IsRequired();

      builder.Property(t => t.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(t => t.Description)
        .HasMaxLength(2000)
        .IsRequired();

      builder.Property(t => t.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.HasOne(t => t.GroupTag)
        .WithMany(gt => gt.Tags)
        .HasForeignKey(t => t.GroupTagId)
        .HasConstraintName("FK_Tags_GroupTags")
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
