using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookingConfiguration : BaseConfiguration<Booking>
{
    public override void Configure(EntityTypeBuilder<Booking> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Total).HasPrecision(18, 2);
        builder.Property(e => e.PaymentMethod).HasConversion<int>();

        builder.HasOne(d => d.User)
               .WithMany(p => p.Bookings)
               .HasForeignKey(d => d.UserId);

        builder.HasOne(d => d.Screening)
               .WithMany(p => p.Bookings)
               .HasForeignKey(d => d.ScreeningId);
    }
}