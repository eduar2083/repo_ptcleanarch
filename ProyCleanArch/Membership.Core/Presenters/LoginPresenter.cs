namespace Membership.Core.Presenters;

internal class LoginPresenter : ILoginOutputPort
{
    readonly IAccessTokenService AccessTokenService;

    public LoginPresenter(IAccessTokenService accessTokenService)
    {
        AccessTokenService = accessTokenService;
    }

    public UserTokensDto Tokens { get; private set; }

    public async Task HandleUserEntityAsync(UserEntity user)
    {
        string AccessToken =
            await AccessTokenService.GetNewUserAccessTokenAsync(user);

        Tokens = new UserTokensDto(AccessToken);
    }
}
