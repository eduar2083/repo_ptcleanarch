namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();

        return services;
    }
}