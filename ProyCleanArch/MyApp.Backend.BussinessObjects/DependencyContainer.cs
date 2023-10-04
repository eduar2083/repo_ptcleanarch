namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddAppBasicServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
