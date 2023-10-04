namespace MyApp.EFCore.Repositories.Mappers;

internal static class UserMapper
{
    public static User ToUser(this RegisterUserDto newUser, IPasswordHasher passwordHasher) =>
        new User
        {
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            PasswordHash = passwordHasher.Hash(newUser.Password),
            OrganizationId = newUser.OrganizationId
        };

    public static UserDto ToUserDto(this User user) =>
        new UserDto(user.Id, user.Email, user.FirstName, user.LastName, user.PasswordHash);
}
