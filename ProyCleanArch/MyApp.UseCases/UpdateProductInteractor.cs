namespace MyApp.UseCases;

internal sealed class UpdateProductInteractor : IUpdateProductInputPort
{
    private readonly IValidator<UpdateProductDto> Validator;
    private readonly IProductRepository ProductRepository;

    public UpdateProductInteractor(IValidator<UpdateProductDto> validator,
        IProductRepository productRepository)
    {
        Validator = validator;
        ProductRepository = productRepository;
    }

    public async Task UpdateAsync(UpdateProductDto product)
    {
        var ValidationErrors = Validator.Validate(product);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        var Product = await ProductRepository.GetByIdAsync(product.Id);
        if (Product == null)
        {
            throw new NotFoundException();
        }

        await ProductRepository.UpdateAsync(product);
    }
}
