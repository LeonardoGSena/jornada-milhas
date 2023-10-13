using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infra.Contexts.TestimonialContext.Mappings;

public class TestimonialMap : IEntityTypeConfiguration<Testimonial>
{
  public void Configure(EntityTypeBuilder<Testimonial> builder)
  {
    builder.ToTable("Testimonial");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
      .HasColumnName("Name")
      .HasColumnType("NVARCHAR")
      .HasMaxLength(120)
      .IsRequired(true);

    builder.Property(x => x.Testimony)
      .HasColumnName("Testimony")
      .HasColumnType("NVARCHAR")
      .HasMaxLength(255)
      .IsRequired(true);

    builder.Property(x => x.Image)
      .HasColumnName("Image")
      .HasColumnType("VARCHAR")
      .HasMaxLength(255)
      .IsRequired(false);
  }
}
