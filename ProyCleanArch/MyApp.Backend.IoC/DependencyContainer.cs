namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMyAppBackendServices(this IServiceCollection services,
        Action<OrganizationConnectionStringsOptions> organizationConnectionStringConfigurator,
        Action<JwtOptions> jwtOptionsConfigurator)
    {
        services.AddSecurityServices(jwtOptionsConfigurator)
            .AddRepositoryServices(organizationConnectionStringConfigurator)
            .AddValidationServices()
            .AddUseCaseServices()
            .AddPresenterServices();

        return services;
    }
}
