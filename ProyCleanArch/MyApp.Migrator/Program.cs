ILogger Logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {TenantName}{Message:lj}{NewLine}{Exception}")
    .CreateLogger();

using IHost MyHost = Host.CreateApplicationBuilder(args)
    .ConfigureConsoleServices();

var OrganizationRepository = MyHost.Services.GetRequiredService<IOrganizationRepository>();
var Organizations = await OrganizationRepository.GetAllAsync();
var Tenants = Organizations.Select(o => new MigratorTenantInfo
{
    TenantId = o.Id,
    ConnectionString = $"Server=(localdb)\\mssqllocaldb; Database={o.Name}; Application Name=MyApp"
});
IEnumerable<Task> Tasks = Tenants.Select(t => MigrateTenantDatabase(t));
try
{
    Logger.Information("Starting parallel execution of pending migrations...");
    await Task.WhenAll(Tasks);
}
catch
{
    Logger.Warning("Parallel execution of pending migrations is complete with error(s).");
    return (int)ExitCode.Error;
}

Logger.Information("Parallel execution of pending migrations is complete.");
return (int)ExitCode.Success;

async Task MigrateTenantDatabase(MigratorTenantInfo tenant)
{
    using var LogCtx = LogContext.PushProperty("TenantId", $"({tenant.TenantId}) ");
    DbContextOptions DbContextOptions = CreateDefaultDbContextOptions(tenant.ConnectionString);
    try
    {
        using var Context = new CrossContext(DbContextOptions);
        await Context.Database.MigrateAsync();
    }
    catch (Exception e)
    {
        Logger.Error(e, "Error occurred during migration");
        throw;
    }
}

DbContextOptions CreateDefaultDbContextOptions(string connectionString) =>
    new DbContextOptionsBuilder()
        .LogTo(action: Logger.Information, filter: MigrationInfoLogFilter(), options: DbContextLoggerOptions.None)
        .UseSqlServer(connectionString)
        .Options;

Func<EventId, LogLevel, bool> MigrationInfoLogFilter() => (eventId, level) =>
    level > LogLevel.Information ||
    (level == LogLevel.Information &&
    new[]
    {
        RelationalEventId.MigrationApplying,
        RelationalEventId.MigrationAttributeMissingWarning,
        RelationalEventId.MigrationGeneratingDownScript,
        RelationalEventId.MigrationGeneratingUpScript,
        RelationalEventId.MigrationReverting,
        RelationalEventId.MigrationsNotApplied,
        RelationalEventId.MigrationsNotFound,
        RelationalEventId.MigrateUsingConnection
    }.Contains(eventId));
