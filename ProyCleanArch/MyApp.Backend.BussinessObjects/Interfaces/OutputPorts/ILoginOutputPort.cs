namespace MyApp.Backend.BussinessObjects.Interfaces.OutputPorts;

public interface ILoginOutputPort
{
    UserTokensDto Tokens { get; }

    Task HandleUserEntityAsync(UserDto user);
}