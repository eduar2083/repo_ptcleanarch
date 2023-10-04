namespace Membership.UserManagerService.AspNetIdentity.Services;

internal class UserManagerErrorsHandler
{
    public IEnumerable<MembershipError> Handle(IEnumerable<IdentityError> errors)
    {
        List<MembershipError> Errors = new();
        foreach (var Error in errors)
        {
            switch (Error.Code)
            {
                case nameof(IdentityErrorDescriber.DuplicateUserName):
                    Errors.Add(new(nameof(User.Email), "El usuario ya existe"));
                    break;

                case nameof(IdentityErrorDescriber.LoginAlreadyAssociated):
                    Errors.Add(new(nameof(User.Email), "Ya existe un usuario con este nombre"));
                    break;

                default:
                    Errors.Add(new(Error.Code, Error.Description));
                    break;

            }
        }
        return Errors;
    }
}
