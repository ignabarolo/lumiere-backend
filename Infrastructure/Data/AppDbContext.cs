
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.Entity is BaseEntity);
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "UserAdmin";
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "UserAdmin";
                    break;
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "UserAdmin";
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "UserAdmin";
                    entry.Entity.State = State.Deleted;
                    break;
            }
        }
        return await base.SaveChangesAsync(ct);
    }

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
