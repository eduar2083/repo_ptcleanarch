namespace MyApp.EFCore.Repositories;

internal sealed class OrganizationRepository : IOrganizationRepository
{
    private readonly MasterContext Context;

    public OrganizationRepository(MasterContext context)
    {
        Context = context;
    }

    public async Task<string> RegisterAsync(RegisterOrganizationDto organization)
    {
        var NewOrganization = organization.ToOrganization();
        NewOrganization.Id = Guid.NewGuid().ToString();
        Context.Add(NewOrganization);

        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return NewOrganization.Id;
    }

    public async Task<IEnumerable<OrganizationDto>> GetAllAsync()
    {
        return await Context.Organizations
            .Select(o => o.ToOrganizationDto())
            .ToListAsync();
    }
}
