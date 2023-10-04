namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
        Action<OrganizationConnectionStringsOptions> connectionStringOptionsConfigurator)
    {
        services.AddOptions<OrganizationConnectionStringsOptions>().Configure(connectionStringOptionsConfigurator);
        services.AddDbContext<OrganizationContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();

        return services;
    }
}
