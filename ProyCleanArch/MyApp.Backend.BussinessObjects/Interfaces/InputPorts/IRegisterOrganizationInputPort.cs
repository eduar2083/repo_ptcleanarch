namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterOrganizationInputPort
{
    Task<string> RegisterAsync(RegisterOrganizationDto organization);
}
