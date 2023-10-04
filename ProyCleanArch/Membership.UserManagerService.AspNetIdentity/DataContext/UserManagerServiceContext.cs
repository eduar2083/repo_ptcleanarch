namespace Membership.UserManagerService.AspNetIdentity.DataContext;

internal class UserManagerServiceContext : IdentityDbContext<User>
{
    readonly AspNetIdentityOptions Options;

    public UserManagerServiceContext(IOptions<AspNetIdentityOptions> options)
    {
        Options = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Options.MembershipDb);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("membership");

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
