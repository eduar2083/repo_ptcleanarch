namespace MyApp.Cross.EFCore.Repositories.Services;

internal sealed class TenantService : ITenantService
{
    private readonly IHttpContextAccessor HttpContextAccessor;
    private readonly CrossConnectionStringOptions CrossConnectionStringOptions;
    private readonly IOrganizationRepository OrganizationRepository;

    public TenantService(IHttpContextAccessor httpContextAccessor,
        IOptions<CrossConnectionStringOptions> options,
        IOrganizationRepository organizationRepository)
    {
        HttpContextAccessor = httpContextAccessor;
        CrossConnectionStringOptions = options.Value;
        OrganizationRepository = organizationRepository;
    }

    public async Task<string> GetConnectionString()
    {
        var Organization = await OrganizationRepository.GetByIdAsync(GetTenantId());

        var ConnectionStringBuilder = new SqlConnectionStringBuilder(CrossConnectionStringOptions.CrossDb);
        ConnectionStringBuilder.InitialCatalog = Organization.Name;

        return ConnectionStringBuilder.ConnectionString;
    }

    #region Helper
    private string GetTenantId()
    {
        var HttpContext = HttpContextAccessor.HttpContext;
        var TenantId = HttpContext.Request.Query["slugTenant"];

        return TenantId;
    }
    #endregion
}
