namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IDeleteProductInputPort
{
    Task<bool> DeleteProductAsync(int id);
}
