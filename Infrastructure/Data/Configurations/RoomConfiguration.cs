using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class RoomConfiguration : BaseConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);

        builder.HasOne(d => d.Cinema)
               .WithMany(p => p.Rooms)
               .HasForeignKey(d => d.CinemaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
