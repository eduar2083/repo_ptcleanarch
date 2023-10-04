namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMasterRepositoryServices(this IServiceCollection services,
        Action<MasterConnectionStringsOptions> connectionStringOptionsConfigurator)
    {
        services.AddOptions<MasterConnectionStringsOptions>().Configure(connectionStringOptionsConfigurator);
        services.AddDbContext<MasterContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();

        return services;
    }
}
