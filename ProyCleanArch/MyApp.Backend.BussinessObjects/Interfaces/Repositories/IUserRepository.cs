namespace MyApp.Backend.BussinessObjects.Interfaces.Repositories;

public interface IUserRepository
{
    Task<string> RegisterAsync(RegisterUserDto user);

    Task<UserDto> GetByUserNameAsync(string userName);
}
