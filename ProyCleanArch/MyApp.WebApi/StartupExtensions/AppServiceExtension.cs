namespace MyApp.WebApi.StartupExtensions;

public static class AppServiceExtension
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        Action<MasterConnectionStringsOptions> MasterConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(MasterConnectionStringsOptions.SectionKey).Bind(options);

        Action<CrossConnectionStringsOptions> CrossConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(CrossConnectionStringsOptions.SectionKey).Bind(options);

        Action<JwtOptions> JwtOptionsConfigurator = options =>
        builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(options);

        builder.Services.AddMyAppBackendServices(MasterConnectionStringOptionsConfigurator,
            CrossConnectionStringOptionsConfigurator,
            JwtOptionsConfigurator);

        return builder;
    }
}
