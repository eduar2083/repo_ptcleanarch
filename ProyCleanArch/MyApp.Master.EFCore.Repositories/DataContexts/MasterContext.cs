namespace MyApp.EFCore.Repositories.DataContexts;

internal sealed class MasterContext : DbContext
{
    private readonly MasterConnectionStringsOptions ConnectionStringsOptions;

    public MasterContext(IOptions<MasterConnectionStringsOptions> options)
    {
        ConnectionStringsOptions = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStringsOptions.MasterDb);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
}
