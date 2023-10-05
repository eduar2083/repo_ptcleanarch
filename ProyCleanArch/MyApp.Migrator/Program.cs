HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);


Action<MasterConnectionStringsOptions> MasterConnectionStringOptionsConfigurator = options =>
builder.Configuration.GetSection(MasterConnectionStringsOptions.SectionKey).Bind(options);

builder.Services.AddMasterRepositoryServices(MasterConnectionStringOptionsConfigurator);

using IHost MyHost = builder.Build();
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var OrganizationRepository = MyHost.Services.GetRequiredService<IOrganizationRepository>();
var Organizations = await OrganizationRepository.GetAllAsync();
foreach (var O in Organizations)
{
    Console.WriteLine(O.Name);
}