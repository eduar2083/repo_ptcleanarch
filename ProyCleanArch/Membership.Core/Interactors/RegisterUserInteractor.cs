namespace Membership.Core.Interactors;

internal class RegisterUserInteractor : IRegisterUserInputPort
{
    readonly IUserManagerService UserManagerService;
    readonly IValidator<RegisterUserDto> Validator;

    public RegisterUserInteractor(IUserManagerService userManagerService,
        IValidator<RegisterUserDto> validator)
    {
        UserManagerService = userManagerService;
        Validator = validator;
    }

    public async Task RegisterAsync(RegisterUserDto user)
    {
        var ValidationErrors = Validator.Validate(user);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new RegisterUserException(ValidationErrors);
        }
        await UserManagerService.ThrowIfUnableToRegisterUserAsync(user);
    }
}
