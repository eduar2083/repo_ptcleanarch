namespace MyApp.Cross.EFCore.Repositories.Services;

internal sealed class MigrationService : IMigrationService
{
    public string BuildConnectionString(string connectionStringTemplate, string databaaseName)
    {
        var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStringTemplate);
        ConnectionStringBuilder.InitialCatalog = databaaseName;

        return ConnectionStringBuilder.ConnectionString;
    }

    public async Task ApplyMigration(MigratorTenantInfo tenant)
    {
        DbContextOptions DbContextOptions = CreateDefaultDbContextOptions(tenant.ConnectionString);
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
}
