namespace Membership.Core.Services;

internal sealed class AccessTokenService : IAccessTokenService
{
    private readonly JwtOptions JwtOptions;
    private readonly IHttpContextAccessor HttpContextAccessor;

    public AccessTokenService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
    {
        JwtOptions = jwtOptions.Value;
        HttpContextAccessor = httpContextAccessor;
    }

    public Task<string> GetNewUserAccessTokenAsync(UserEntity user)
    {
        var HttpContext = HttpContextAccessor.HttpContext;
        var ClientId = HttpContext.Request.Headers["clientId"].ToString();

        return Task.FromResult(JwtHelper.GetAccessToken(JwtOptions,
        ClientId,
            JwtHelper.GetUserClaims(user)));
    }

    public Task<string> RotateAccessTokenAsync(string accessTokenToRotate)
    {
        var HttpContext = HttpContextAccessor.HttpContext;
        var ClientId = HttpContext.Request.Headers["clientId"];

        return Task.FromResult(JwtHelper.GetAccessToken(JwtOptions,
        ClientId,
            JwtHelper.GetUserClaimsFromToken(accessTokenToRotate)));
    }
}