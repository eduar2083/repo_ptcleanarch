namespace MyApp.WebApi.StartupExtensions;

public static class AppServiceExtension
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        Action<OrganizationConnectionStringsOptions> OrganizationConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(OrganizationConnectionStringsOptions.SectionKey).Bind(options);

        Action<ProductConnectionStringsOptions> ProductConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(ProductConnectionStringsOptions.SectionKey).Bind(options);

        Action<JwtOptions> JwtOptionsConfigurator = options =>
        builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(options);

        builder.Services.AddMyAppBackendServices(OrganizationConnectionStringOptionsConfigurator,
            JwtOptionsConfigurator);

        return builder;
    }
}
