using GameStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<GameEntity> Games { get; set; } = null!;
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //         var connectionString = configuration.GetConnectionString("DefaultConnection");
    //         optionsBuilder.UseSqlServer(connectionString);
    //     }
    // }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameEntity>()
            .HasIndex(u => u.Alias)
            .IsUnique();
    }
}