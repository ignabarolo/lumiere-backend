
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Seed();
    }

    public DbSet<Booking> Booking { get; set; }
    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Screening> Screening { get; set; }
    public DbSet<Seat> Seat { get; set; }
    public DbSet<User> User { get; set; }
}
