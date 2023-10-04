namespace Membership.Core.Interactors;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipInteractors(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserInputPort, RegisterUserInteractor>();
        services.AddScoped<ILoginInputPort, LoginInteractor>();

        return services;
    }
}

