namespace Membership.Abstractions.Interfaces.Login;

public interface ILoginOutputPort
{
    UserTokensDto Tokens { get; }
    Task HandleUserEntityAsync(UserEntity user);
}
