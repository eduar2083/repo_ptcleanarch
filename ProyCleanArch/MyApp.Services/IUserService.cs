namespace MyApp.Services;

internal sealed class UserService : IUserService
{
    private readonly IHttpContextAccessor ContextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        ContextAccessor = contextAccessor;
    }

    public bool IsAuthenticated => ContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false;

    public string UserId => ContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string UserName => ContextAccessor.HttpContext.User.Identity?.Name;

    public string FullName => ContextAccessor.HttpContext.User
        .Claims.Where(c => c.Type == "fullName")
        .Select(c => c.Value)
        .FirstOrDefault();

    public string OrganizationId => ContextAccessor.HttpContext.User
        .Claims.Where(c => c.Type == "slugTenant")
        .Select(c => c.Value)
        .FirstOrDefault();
}
