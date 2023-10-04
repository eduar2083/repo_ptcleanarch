namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMyAppBackendServices(this IServiceCollection services,
        Action<OrganizationConnectionStringsOptions> organizationConnectionStringConfigurator)
    {
        services.AddAppBasicServices()
            .AddRepositoryServices(organizationConnectionStringConfigurator)
            .AddValidationServices()
            .AddUseCaseServices();

        return services;
    }
}
