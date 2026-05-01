using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class SeatConfiguration : BaseConfiguration<Seat>
{
    public override void Configure(EntityTypeBuilder<Seat> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Row).IsRequired().HasMaxLength(5);

        builder.HasOne(d => d.Room)
               .WithMany(p => p.Seats)
               .HasForeignKey(d => d.RoomId);
    }
}
