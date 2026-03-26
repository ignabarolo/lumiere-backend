using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CinemaConfiguration : BaseConfiguration<Cinema>
{
    public override void Configure(EntityTypeBuilder<Cinema> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(500);

        builder.HasMany(e => e.Rooms)
                .WithOne(r => r.Cinema)
                .HasForeignKey(r => r.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
