namespace Membership.Shared.Dtos;

public class UserTokensDto
{
    public string AccessToken { get; }

    public UserTokensDto(string accessToken)
    {
        AccessToken = accessToken;
    }
}
