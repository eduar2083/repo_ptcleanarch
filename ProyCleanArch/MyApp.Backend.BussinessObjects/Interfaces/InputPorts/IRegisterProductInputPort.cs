namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IRegisterProductInputPort
{
    Task<int> RegisterAsync(RegisterProductDto product);
}
