namespace MyApp.Presenters;

internal sealed class LoginPresenter : ILoginOutputPort
{
    private readonly IAccessTokenService AccessTokenService;

    public LoginPresenter(IAccessTokenService accessTokenService)
    {
        AccessTokenService = accessTokenService;
    }

    public async Task HandleUserEntityAsync(UserDto user)
    {
        string AccessToken = await AccessTokenService.GetNewUserAccessTokenAsync(user);

        Tokens = new UserTokensDto(AccessToken);
    }

    public UserTokensDto Tokens { get; private set; }
}
