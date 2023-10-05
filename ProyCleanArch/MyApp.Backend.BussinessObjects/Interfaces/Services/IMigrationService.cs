namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IMigrationService
{
    string BuildConnectionString(string connectionStringTemplate, string databaseName);
    Task ApplyMigration(MigratorTenantInfo tenant);
}
