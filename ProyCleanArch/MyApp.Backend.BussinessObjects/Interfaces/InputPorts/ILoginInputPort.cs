namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface ILoginInputPort
{
    Task Login(UserCredentialsDto userCredentials);
}
