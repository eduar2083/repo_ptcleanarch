namespace MyApp.Backend.BussinessObjects.Interfaces.Repositories;

public interface IProductRepository
{
    Task<int> RegisterAsync(RegisterProductDto product);
    Task UpdateAsync(UpdateProductDto product);
    Task<ProductDto> GetByIdAsync(int id);
    Task<List<ProductDto>> ListAsync();
    Task<bool> DeleteAsync(int id);
}
