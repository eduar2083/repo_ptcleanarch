namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterUserInputPort
{
    Task<string> RegisterAsync(RegisterUserDto user);
}
