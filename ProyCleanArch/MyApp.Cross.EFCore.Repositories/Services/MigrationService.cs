namespace MyApp.Cross.EFCore.Repositories.Services;

internal sealed class MigrationService : IMigrationService
{
    private readonly CrossConnectionStringOptions CrossConnectionStringOptions;

    public MigrationService(IOptions<CrossConnectionStringOptions> options)
    {
        CrossConnectionStringOptions = options.Value;
    }

    public async Task ApplyMigration(MigratorTenantInfo tenant)
    {
        var ConnectionString = BuildConnectionString(CrossConnectionStringOptions.CrossDb, tenant.TenantId);
        DbContextOptions DbContextOptions = CreateDefaultDbContextOptions(ConnectionString);
        try
        {
            using var Context = new CrossContext(DbContextOptions);
            await Context.Database.MigrateAsync();
        }
        catch
        {
            throw new MigrationApplyException();
        }
    }

    DbContextOptions CreateDefaultDbContextOptions(string connectionString) =>
    new DbContextOptionsBuilder()
        .UseSqlServer(connectionString)
        .Options;

    #region Helper
    private string BuildConnectionString(string connectionStringTemplate, string databaseName)
    {
        var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStringTemplate);
        ConnectionStringBuilder.InitialCatalog = databaseName;

        return ConnectionStringBuilder.ConnectionString;
    }
    #endregion
}
