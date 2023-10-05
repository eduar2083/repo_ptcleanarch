namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IGetProductByIdInputPort
{
    Task<ProductDto> GetByIdAsync(int id);
}
