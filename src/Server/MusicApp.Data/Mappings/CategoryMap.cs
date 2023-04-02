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
  public class CategoryMap : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Categoires");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Name)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(c => c.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(c => c.Description)
        .HasMaxLength(2000)
        .IsRequired();

      builder.Property(c => c.Enable)
        .IsRequired()
        .HasDefaultValue(true);
    }
  }
}
