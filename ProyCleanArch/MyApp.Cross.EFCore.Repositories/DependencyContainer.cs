namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCrossRepositoryServices(this IServiceCollection services,
        Action<CrossConnectionStringOptions> connectionStringOptionsConfigurator)
    {
        services.AddOptions<CrossConnectionStringOptions>().Configure(connectionStringOptionsConfigurator);
        services.AddDbContext<CrossContext>();

        services.AddScoped<IMigrationService, MigrationService>();
        services.AddScoped<ITenantService, TenantService>();

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
