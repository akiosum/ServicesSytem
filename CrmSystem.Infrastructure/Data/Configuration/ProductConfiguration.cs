using CrmSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrmSystem.Infrastructure.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.Property(p => p.Name)
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .HasPrecision(18, 3);
        
        builder.Property(p => p.Cost)
            .HasPrecision(18, 3);
    }
}