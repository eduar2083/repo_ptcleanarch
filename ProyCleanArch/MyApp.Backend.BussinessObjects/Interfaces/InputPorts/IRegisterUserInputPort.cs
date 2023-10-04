namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterUserInputPort
{
    Task<string> Register(RegisterUserDto user);
}
