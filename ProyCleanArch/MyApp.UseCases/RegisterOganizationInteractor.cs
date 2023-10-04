namespace MyApp.UseCases;

internal sealed class RegisterOganizationInteractor : IRegisterOrganizationInputPort
{
    private readonly IValidator<RegisterOrganizationDto> Validator;
    private readonly IOrganizationRepository OrganizationRepository;

    public RegisterOganizationInteractor(IValidator<RegisterOrganizationDto> validator,
        IOrganizationRepository organizationRepository)
    {
        Validator = validator;
        OrganizationRepository = organizationRepository;
    }

    public async Task<string> Register(RegisterOrganizationDto organization)
    {
        var ValidationErrors = Validator.Validate(organization);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        return await OrganizationRepository.RegisterAsync(organization);
    }
}
