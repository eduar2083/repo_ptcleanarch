namespace MyApp.UseCases;

internal sealed class LoginInteractor : ILoginInputPort
{
    private readonly IValidator<UserCredentialsDto> Validator;
    private readonly IUserRepository UserRepository;
    private readonly IPasswordHasher PasswordHasher;
    private readonly ILoginOutputPort OutputPort;

    public LoginInteractor(IValidator<UserCredentialsDto> validator,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ILoginOutputPort outputPort)
    {
        Validator = validator;
        UserRepository = userRepository;
        PasswordHasher = passwordHasher;
        OutputPort = outputPort;
    }

    public async Task Login(UserCredentialsDto userCredentials)
    {
        var ValidationErrors = Validator.Validate(userCredentials);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        UserDto FoundUser = default;
        var User = await UserRepository.GetByUserName(userCredentials.UserName);
        if (User != null && PasswordHasher.Check(User.PasswordHash, userCredentials.Password))
        {
            FoundUser = User;
        }

        if (FoundUser == default)
        {
            throw new LoginUserException();
        }

        await OutputPort.HandleUserEntityAsync(FoundUser);
    }
}
