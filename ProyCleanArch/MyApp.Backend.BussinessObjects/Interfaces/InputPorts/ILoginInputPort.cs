namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface ILoginInputPort
{
    Task LoginAsync(UserCredentialsDto userCredentials);
}
