namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterOrganizationInputPort
{
    Task<string> Register(RegisterOrganizationDto organization);
}
