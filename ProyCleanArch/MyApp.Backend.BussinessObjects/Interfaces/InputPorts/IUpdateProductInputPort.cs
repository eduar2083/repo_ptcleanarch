namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IUpdateProductInputPort
{
    Task UpdateAsync(UpdateProductDto product);
}
