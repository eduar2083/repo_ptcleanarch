namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterProductInputPort
{
    Task<int> Register(RegisterProductDto product);
}
