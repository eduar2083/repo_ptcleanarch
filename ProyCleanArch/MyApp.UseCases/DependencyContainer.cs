namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserInputPort, RegisterUserInteractor>();

        return services;
    }
}
