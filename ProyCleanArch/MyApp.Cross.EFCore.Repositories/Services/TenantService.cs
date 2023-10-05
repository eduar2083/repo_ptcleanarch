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

    public string GetConnectionString()
    {
        var ConnectionStringBuilder = new SqlConnectionStringBuilder(CrossConnectionStringOptions.CrossDb);
        ConnectionStringBuilder.InitialCatalog = GetTenantId();

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
