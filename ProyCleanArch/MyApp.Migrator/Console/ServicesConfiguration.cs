namespace MyApp.Migrator.Console;

internal static class ServicesConfiguration
{
    public static IHost ConfigureConsoleServices(this HostApplicationBuilder builder)
    {
        Action<MasterConnectionStringsOptions> MasterConnectionStringOptionsConfigurator = options =>
        builder.Configuration.GetSection(MasterConnectionStringsOptions.SectionKey).Bind(options);

        builder.Services.AddMasterRepositoryServices(MasterConnectionStringOptionsConfigurator);

        return builder.Build();
    }
}
