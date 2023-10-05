namespace MyApp.UseCases;

internal sealed class GetProductByIdInteractor : IGetProductByIdInputPort
{
    private readonly IProductRepository ProductRepository;

    public GetProductByIdInteractor(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var Product = await ProductRepository.GetByIdAsync(id);
        if (Product == null)
        {
            throw new NotFoundException();
        }

        return Product;
    }
}
