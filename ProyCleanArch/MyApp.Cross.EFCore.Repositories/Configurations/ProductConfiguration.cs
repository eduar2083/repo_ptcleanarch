﻿namespace MyApp.Cross.EFCore.Repositories.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.UnitPrice)
            .HasPrecision(8, 2);

        builder.Property(p => p.OrganizationId)
            .IsRequired()
            .HasMaxLength(72);

        builder.HasIndex(p => p.OrganizationId)
            .IsClustered(false);

        builder.HasIndex(p => p.Name)
            .IsUnique(true);
    }
}
