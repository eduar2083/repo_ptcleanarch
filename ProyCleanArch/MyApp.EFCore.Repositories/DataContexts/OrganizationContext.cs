namespace MyApp.EFCore.Repositories.DataContexts;

internal class OrganizationContext : DbContext
{
    private readonly OrganizationConnectionStringsOptions ConnectionStringsOptions;

    public OrganizationContext(IOptions<OrganizationConnectionStringsOptions> connectionStringsOptions)
    {
        ConnectionStringsOptions = connectionStringsOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStringsOptions.OrganizationDb);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
}
