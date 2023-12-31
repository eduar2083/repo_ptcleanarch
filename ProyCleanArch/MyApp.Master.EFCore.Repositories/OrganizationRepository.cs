﻿namespace MyApp.EFCore.Repositories;

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

        try
        {
            Context.Add(NewOrganization);
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return NewOrganization.Id;
    }

    public async Task<IEnumerable<OrganizationDto>> ListAsync()
    {
        return await Context.Organizations
            .Select(o => o.ToOrganizationDto())
            .ToListAsync();
    }

    public async Task<OrganizationDto> GetByIdAsync(string id)
    {
        return await Context.Organizations
            .Select(o => o.ToOrganizationDto())
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync();
    }
}
