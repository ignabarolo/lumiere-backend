
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(e => e.Created).IsRequired();
        builder.Property(e => e.CreatedBy).HasMaxLength(100);
        builder.Property(e => e.Modified).IsRequired();
        builder.Property(e => e.ModifiedBy).HasMaxLength(100);

        builder.Property(e => e.State).HasConversion<int>().IsRequired();
    }
}
