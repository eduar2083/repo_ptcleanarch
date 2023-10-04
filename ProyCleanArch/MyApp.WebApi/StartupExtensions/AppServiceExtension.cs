namespace MyApp.WebApi.StartupExtensions;

public static class AppServiceExtension
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        Action<CompanyConnectionStringsOptions> CompanyConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(CompanyConnectionStringsOptions.SectionKey).Bind(options);

        Action<ProductConnectionStringsOptions> ProductConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(ProductConnectionStringsOptions.SectionKey).Bind(options);

        //Action<JwtOptions> JwtOptionsConfigurator = options =>
        //builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(options);

        return builder;
    }
}
