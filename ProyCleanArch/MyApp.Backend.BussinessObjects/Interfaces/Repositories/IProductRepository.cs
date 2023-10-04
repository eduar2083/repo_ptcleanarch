namespace MyApp.Backend.BussinessObjects.Interfaces.Repositories;

public interface IProductRepository
{
    Task<int> RegisterAsync(RegisterProductDto product);

}
