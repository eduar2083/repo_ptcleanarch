namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCrossRepositoryServices(this IServiceCollection services,
        Action<CrossConnectionStringsOptions> connectionStringOptionsConfigurator)
    {
        services.AddOptions<CrossConnectionStringsOptions>().Configure(connectionStringOptionsConfigurator);
        services.AddDbContext<CrossContext>();

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
