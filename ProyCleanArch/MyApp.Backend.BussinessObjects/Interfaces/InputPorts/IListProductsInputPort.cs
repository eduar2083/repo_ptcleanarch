namespace MyApp.Backend.BussinessObjects.Interfaces.InputPorts;

public interface IListProductsInputPort
{
    Task<List<ProductDto>> ListProductsAsync();
}
