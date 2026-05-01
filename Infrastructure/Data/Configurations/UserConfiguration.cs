using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.First_Name).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Last_Name).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Phone).HasMaxLength(20);
    }
}
