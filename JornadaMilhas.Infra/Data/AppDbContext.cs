using JornadaMilhas.Core.Contexts.TestimonialContext.Entities;
using JornadaMilhas.Infra.Contexts.TestimonialContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infra.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

  public DbSet<Testimonial> Testimonials { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new TestimonialMap());
  }
}
