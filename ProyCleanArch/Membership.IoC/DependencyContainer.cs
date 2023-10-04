namespace Membership.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipServices(this IServiceCollection services,
        Action<JwtOptions> jwtOptionsConfigurator)
    {
        services.AddMembershipCoreServices(jwtOptionsConfigurator);

        return services;
    }

    public static IServiceCollection AddMembershipExtensionServices(this IServiceCollection services,
        Action<AspNetIdentityOptions> aspNetIdentityOptionsConfigurator)
    {
        return services.AddMembershipValidators()
            .AddUserManagerAspNetIdentityService(aspNetIdentityOptionsConfigurator);
    }

    public static WebApplication UseMembershipEndpoints(this WebApplication app) =>
        app.UseMembershipControllers();
}
