
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Booking> Booking { get; set; }
    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Screening> Screening { get; set; }
    public DbSet<Seat> Seat { get; set; }
    public DbSet<User> User { get; set; }

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
                    HandleSoftDelete(entry);
                    break;
            }
        }
        return await base.SaveChangesAsync(ct);
    }

    private void HandleSoftDelete(EntityEntry<BaseEntity> entry)
    {
        entry.State = EntityState.Modified;
        entry.Entity.Modified = DateTime.UtcNow;
        entry.Entity.ModifiedBy = "UserAdmin";
        entry.Entity.State = State.Deleted;

        foreach (var navigationEntry in entry.Navigations)
        {
            if (navigationEntry is CollectionEntry collectionEntry && collectionEntry.CurrentValue != null)
            {
                foreach (var dependentEntity in collectionEntry.CurrentValue)
                {
                    if (dependentEntity is BaseEntity child)
                    {
                        var childEntry = Entry(child);
                        if (childEntry.State != EntityState.Deleted && child.State != State.Deleted)
                        {
                            HandleSoftDelete(childEntry);
                        }
                    }
                }
            }
            else if (navigationEntry is ReferenceEntry referenceEntry && referenceEntry.CurrentValue is BaseEntity child)
            {
                var childEntry = Entry(child);
                HandleSoftDelete(childEntry);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

            foreach (var property in properties)
            {
                property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                    v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc),
                    v => v));
            }
        }

        modelBuilder.Seed();
    }
}
