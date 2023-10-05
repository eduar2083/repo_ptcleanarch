namespace MyApp.UseCases;

internal sealed class RegisterOganizationInteractor : IRegisterOrganizationInputPort
{
    private readonly IValidator<RegisterOrganizationDto> Validator;
    private readonly IOrganizationRepository OrganizationRepository;
    private readonly IMigrationService MigrationService;
    private readonly CrossConnectionStringOptions CrossConnectionStringOptions;

    public RegisterOganizationInteractor(IValidator<RegisterOrganizationDto> validator,
        IOrganizationRepository organizationRepository,
        IMigrationService migrationService,
        IOptions<CrossConnectionStringOptions> options)
    {
        Validator = validator;
        OrganizationRepository = organizationRepository;
        MigrationService = migrationService;
        CrossConnectionStringOptions = options.Value;
    }

    public async Task<string> Register(RegisterOrganizationDto organization)
    {
        var ValidationErrors = Validator.Validate(organization);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        var Id = await OrganizationRepository.RegisterAsync(organization);

        await MigrationService.ApplyMigration(new MigratorTenantInfo
        {
            TenantId = Id,
            ConnectionString = MigrationService.BuildConnectionString(
                CrossConnectionStringOptions.CrossDb, organization.Name)
        });

        return Id;
    }
}
