namespace MyApp.UseCases;

internal sealed class RegisterUserInteractor : IRegisterUserInputPort
{
    private readonly IValidator<RegisterUserDto> Validator;
    private readonly IUserRepository UserRepository;

    public RegisterUserInteractor(IUserRepository userRepository,
        IValidator<RegisterUserDto> validator)
    {
        UserRepository = userRepository;
        Validator = validator;
    }

    public async Task<string> RegisterAsync(RegisterUserDto user)
    {
        var ValidationErrors = Validator.Validate(user);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        return await UserRepository.RegisterAsync(user);
    }
}
