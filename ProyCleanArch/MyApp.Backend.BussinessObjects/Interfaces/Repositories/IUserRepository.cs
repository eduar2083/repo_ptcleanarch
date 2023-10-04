namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IUserRepository
{
    Task<string> RegisterAsync(RegisterUserDto user);

    Task<UserDto> GetByUserName(string userName);
}
