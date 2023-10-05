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

    public async Task<string> RegisterAsync(RegisterOrganizationDto organization)
    {
        var ValidationErrors = Validator.Validate(organization);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        var OrganizationId = await OrganizationRepository.RegisterAsync(organization);

        string TenantId = $"{organization.Name}-{OrganizationId}";
        await MigrationService.ApplyMigration(new MigratorTenantInfo
        {
            TenantId = TenantId,
            ConnectionString = MigrationService.BuildConnectionString(
                CrossConnectionStringOptions.CrossDb, TenantId)
        });

        return OrganizationId;
    }
}
