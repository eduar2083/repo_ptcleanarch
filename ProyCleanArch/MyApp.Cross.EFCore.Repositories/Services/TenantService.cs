namespace MyApp.Cross.EFCore.Repositories.Services;

internal sealed class TenantService : ITenantService
{
    private readonly IHttpContextAccessor HttpContextAccessor;
    private readonly CrossConnectionStringOptions CrossConnectionStringOptions;
    private readonly IUserService UserService;

    public TenantService(IHttpContextAccessor httpContextAccessor,
        IOptions<CrossConnectionStringOptions> options,
        IUserService userService)
    {
        HttpContextAccessor = httpContextAccessor;
        CrossConnectionStringOptions = options.Value;
        UserService = userService;
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
        var TenantId = HttpContext.Request.Query["slugTenant"].ToString();
        var OrganizationId = UserService.OrganizationId;

        if (!TenantId.Contains(OrganizationId))
        {
            throw new ForbiddenAccessException();
        }

        return TenantId;
    }
    #endregion
}
