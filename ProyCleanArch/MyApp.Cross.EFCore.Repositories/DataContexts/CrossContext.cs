namespace MyApp.Cross.EFCore.Repositories.DataContexts;

internal sealed class CrossContext : DbContext
{
    private readonly CrossConnectionStringsOptions ConnectionStringsOptions;

    public CrossContext(IOptions<CrossConnectionStringsOptions> options)
    {
        ConnectionStringsOptions = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStringsOptions.CrossDb);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; }
}
