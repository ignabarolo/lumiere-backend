using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ScreeningConfiguration : BaseConfiguration<Screening>
{
    public override void Configure(EntityTypeBuilder<Screening> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);

        builder.HasOne(d => d.Room)
               .WithMany(p => p.Screenings)
               .HasForeignKey(d => d.RoomId);

        builder.HasOne(d => d.Movie)
               .WithMany(p => p.Screenings)
               .HasForeignKey(d => d.MovieId);
    }
}
