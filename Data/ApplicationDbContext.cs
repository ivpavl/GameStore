using GameStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<GameEntity> Games { get; set; } = null!;
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameEntity>()
            .HasIndex(u => u.Alias)
            .IsUnique();
    }
}