using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace DAL;

public class EfDbContextFactory : IDesignTimeDbContextFactory<EfDbContext>
{
    public EfDbContext CreateDbContext(string[] args)
    {
        
        var builder = new DbContextOptionsBuilder<EfDbContext>();
        // Change the connection string to a more generic or configurable one
        builder.UseNpgsql("Host=localhost;Database=MelodyMineDb;Username=Adrian;Password=123456;");
        return new EfDbContext(builder.Options);
    }
}

public class EfDbContext : DbContext
{
    public EfDbContext(DbContextOptions<EfDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseNpgsql("Host=localhost;Database=MelodyMineDb;Username=Adrian;Password=123456;");
        }
    }

    // DbSet properties - these should be adapted or made more generic
    // For example, by using generic methods to add DbSets from outside

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add your model configurations here
        // For example, relationships and key configurations
    }

    // Consider adding methods here that allow dynamic addition of DbSets or configurations
}

// ======================================================================
// NuGet Package Summary for Future Projects
// ======================================================================
//
// Remember to install the following NuGet packages in future projects:
//
// 1. Microsoft.EntityFrameworkCore.Relational
//    - Essential for projects using relational databases with EF Core.
//
// 2. Microsoft.EntityFrameworkCore.Design
//    - Required for EF Core design-time activities, like migrations.
//
// 3. Microsoft.AspNetCore.Identity.EntityFrameworkCore
//    - Integrates ASP.NET Core Identity with EF Core for user data storage.
//
// 4. Npgsql.EntityFrameworkCore.PostgresSQL
//    - PostgresSQL database provider for EF Core.
//
// Including these packages ensures functionality for database operations,
// identity management, and JSON processing is covered.
// ======================================================================

