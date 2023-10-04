namespace MyApp.Services;

internal sealed class AccessTokenService : IAccessTokenService
{
    private readonly JwtOptions JwtOptions;
    private readonly IHttpContextAccessor HttpContextAccessor;

    public AccessTokenService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
    {
        JwtOptions = jwtOptions.Value;
        HttpContextAccessor = httpContextAccessor;
    }

    public Task<string> GetNewUserAccessTokenAsync(UserDto user)
    {
        var HttpContext = HttpContextAccessor.HttpContext;

        return Task.FromResult(JwtHelper.GetAccessToken(JwtOptions,
            JwtHelper.GetUserClaims(user)));
    }
}
