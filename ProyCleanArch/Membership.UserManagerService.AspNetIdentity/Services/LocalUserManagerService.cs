namespace Membership.UserManagerService.AspNetIdentity.Services;

internal partial class UserManagerService
{
    public async Task<IEnumerable<MembershipError>> RegisterUserAsync(RegisterUserDto user)
    {
        IEnumerable<MembershipError> Errors = null;

        var User = new User
        {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        var Result = await UserManager.CreateAsync(User, user.Password);
        if (!Result.Succeeded)
        {
            Errors = ErrorsHandler.Handle(Result.Errors);
        }

        return Errors;
    }

    public async Task<UserEntity> GetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        UserEntity FoundUser = default;
        var User = await UserManager.FindByNameAsync(userCredentials.Email);
        if (User != null &&
            await UserManager.CheckPasswordAsync(User, userCredentials.Password))
        {
            var Roles = await UserManager.GetRolesAsync(User);
            FoundUser = new UserEntity(User.Id, User.UserName,
                User.FirstName, User.LastName, Roles.ToArray());
        }
        return FoundUser;
    }
}
