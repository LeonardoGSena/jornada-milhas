using JornadaMilhas.Core;
using JornadaMilhas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Api.Extensions;

public static class BuilderExtension
{
  public static void AddConfiguration(this WebApplicationBuilder builder)
  {
    Configuration.Database.ConnectionString =
      builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
  }

  public static void AddDatabase(this WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<AppDbContext>(
      x => x.UseSqlServer(
        Configuration.Database.ConnectionString,
        b => b.MigrationsAssembly("JornadaMilhas.Api")
      )
    );
  }
}
