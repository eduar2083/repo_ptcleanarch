namespace MyApp.Backend.BussinessObjects.Interfaces.Repositories;

public interface IOrganizationRepository
{
    Task<string> RegisterAsync(RegisterOrganizationDto organization);
    Task<IEnumerable<OrganizationDto>> GetAllAsync();
    Task<OrganizationDto> GetByIdAsync(string id);
}
