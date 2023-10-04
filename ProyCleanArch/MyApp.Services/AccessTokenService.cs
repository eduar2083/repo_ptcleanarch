namespace MyApp.Services;

internal sealed class AccessTokenService : IAccessTokenService
{
    private readonly JwtOptions JwtOptions;

    public AccessTokenService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
    {
        JwtOptions = jwtOptions.Value;
    }

    public Task<string> GetNewUserAccessTokenAsync(UserDto user)
    {
        return Task.FromResult(JwtHelper.GetAccessToken(JwtOptions,
            JwtHelper.GetUserClaims(user)));
    }
}
