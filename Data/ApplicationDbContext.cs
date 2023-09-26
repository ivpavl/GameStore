using GameStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<GameEntity> Games { get; set; } = null!;
    public DbSet<GenreEntity> Genres { get; set; } = null!;
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameEntity>()
            .HasIndex(x => x.Alias)
            .IsUnique();

        builder.Entity<GenreEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();
    }
}