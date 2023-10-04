namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IAccessTokenService
{
    Task<string> GetNewUserAccessTokenAsync(UserDto user);
}