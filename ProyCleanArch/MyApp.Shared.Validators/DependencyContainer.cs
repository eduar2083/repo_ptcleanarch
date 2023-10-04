namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
        services.AddScoped<IValidator<RegisterOrganizationDto>, RegisterOrganizationValidator>();
        services.AddScoped<IValidator<UserCredentialsDto>, UserCredentialsValidator>();
        services.AddScoped<IValidator<RegisterProductDto>, RegisterProductValidator>();

        return services;
    }
}