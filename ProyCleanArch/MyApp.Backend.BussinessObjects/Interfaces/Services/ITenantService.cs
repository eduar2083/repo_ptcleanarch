namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface ITenantService
{
    Task<string> GetConnectionString();
}
