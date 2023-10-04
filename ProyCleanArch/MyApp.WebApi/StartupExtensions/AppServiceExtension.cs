namespace MyApp.WebApi.StartupExtensions;

public static class AppServiceExtension
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        Action<CompanyConnectionStringsOptions> CompanyConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(CompanyConnectionStringsOptions.SectionKey).Bind(options);

        Action<ProductConnectionStringsOptions> ProductConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(ProductConnectionStringsOptions.SectionKey).Bind(options);

        Action<AspNetIdentityOptions> AspNetIdentityOptionsConfigurator = options =>
        builder.Configuration.GetSection(AspNetIdentityOptions.SectionKey).Bind(options);

        Action<JwtOptions> JwtOptionsConfigurator = options =>
        builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(options);

        // Membership Services
        builder.Services
            .AddMembershipServices(JwtOptionsConfigurator)
            .AddMembershipExtensionServices(AspNetIdentityOptionsConfigurator);

        return builder;
    }
}
