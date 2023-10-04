namespace Membership.Core;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipCoreServices(
        this IServiceCollection services,
        Action<JwtOptions> jwtOptionsSetter)
    {
        services.AddMembershipInteractors()
            .AddMembershipPresenters()
            .AddMembershipInternalServices(jwtOptionsSetter);

        return services;
    }
}

