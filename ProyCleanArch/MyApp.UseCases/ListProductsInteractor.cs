namespace MyApp.UseCases;

internal sealed class ListProductsInteractor : IListProductsInputPort
{
    private readonly IProductRepository ProductRepository;

    public ListProductsInteractor(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public async Task<List<ProductDto>> ListAsync()
    {
        return await ProductRepository.ListAsync();
    }
}
