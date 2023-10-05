namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMyAppBackendServices(this IServiceCollection services,
        Action<MasterConnectionStringsOptions> masterConnectionStringConfigurator,
        Action<CrossConnectionStringOptions> crossConnectionstringConfigurator,
        Action<JwtOptions> jwtOptionsConfigurator)
    {
        services.AddSecurityServices(jwtOptionsConfigurator)
            .AddMasterRepositoryServices(masterConnectionStringConfigurator)
            .AddCrossRepositoryServices(crossConnectionstringConfigurator)
            .AddValidationServices()
            .AddUseCaseServices()
            .AddPresenterServices();

        return services;
    }
}
