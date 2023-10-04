namespace Membership.Abstractions.Interfaces.Services;

public interface IUserManagerService
{
    Task<IEnumerable<MembershipError>> RegisterUserAsync(RegisterUserDto user);

    Task<UserEntity> GetUserByCredentialsAsync(UserCredentialsDto userCredentials);

    async Task ThrowIfUnableToRegisterUserAsync(RegisterUserDto user)
    {
        var Errors = await RegisterUserAsync(user);
        if (Errors != null && Errors.Any())
            throw new RegisterUserException(Errors);
    }

    async Task<UserEntity> ThrowIfUnableToGetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        var User = await GetUserByCredentialsAsync(userCredentials);
        if (User == default)
            throw new LoginUserException();
        return User;
    }
}
