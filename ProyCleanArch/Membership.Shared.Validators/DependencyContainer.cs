namespace Membership.Shared.Validators;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
        services.AddScoped<IValidator<UserCredentialsDto>, UserCredentialsValidator>();

        return services;
    }
}