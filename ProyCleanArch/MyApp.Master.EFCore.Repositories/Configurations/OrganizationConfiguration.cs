namespace MyApp.Master.EFCore.Repositories.Configurations;

internal sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(o => o.Id)
            .HasMaxLength(72);

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(o => o.Name)
            .IsUnique(true);
    }
}
