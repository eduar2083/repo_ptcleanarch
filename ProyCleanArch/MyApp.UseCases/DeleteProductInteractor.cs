namespace MyApp.UseCases;

internal sealed class DeleteProductInteractor : IDeleteProductInputPort
{
    private readonly IProductRepository ProductRepository;

    public DeleteProductInteractor(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var Product = await ProductRepository.GetByIdAsync(id);
        if (Product == null)
        {
            throw new NotFoundException();
        }

        return await ProductRepository.DeleteAsync(id);
    }
}
