namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services,
        Action<JwtOptions> jwtOptionsConfigurator)
    {
        services.AddHttpContextAccessor();

        services.AddOptions<JwtOptions>().Configure(jwtOptionsConfigurator);

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddSingleton<IUserService, UserService>();

        return services;
    }
}
