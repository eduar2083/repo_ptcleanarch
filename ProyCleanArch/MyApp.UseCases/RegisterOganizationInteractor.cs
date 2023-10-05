namespace MyApp.UseCases;

internal sealed class RegisterOganizationInteractor : IRegisterOrganizationInputPort
{
    private readonly IValidator<RegisterOrganizationDto> Validator;
    private readonly IOrganizationRepository OrganizationRepository;
    private readonly IMigrationService MigrationService;

    public RegisterOganizationInteractor(IValidator<RegisterOrganizationDto> validator,
        IOrganizationRepository organizationRepository,
        IMigrationService migrationService,
        IOptions<CrossConnectionStringOptions> options)
    {
        Validator = validator;
        OrganizationRepository = organizationRepository;
        MigrationService = migrationService;
    }

    public async Task<string> RegisterAsync(RegisterOrganizationDto organization)
    {
        var ValidationErrors = Validator.Validate(organization);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        var OrganizationId = await OrganizationRepository.RegisterAsync(organization);

        await MigrationService.ApplyMigration(new MigratorTenantInfo
        {
            TenantId = $"{organization.Name}-{OrganizationId}"
        });

        return OrganizationId;
    }
}
