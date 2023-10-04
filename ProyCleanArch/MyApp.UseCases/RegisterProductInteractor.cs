namespace MyApp.UseCases;

internal sealed class RegisterProductInteractor : IRegisterProductInputPort
{
    private readonly IValidator<RegisterProductDto> Validator;
    private readonly IProductRepository ProductRepository;

    public RegisterProductInteractor(IValidator<RegisterProductDto> validator,
        IProductRepository productRepository)
    {
        Validator = validator;
        ProductRepository = productRepository;
    }

    public async Task<int> Register(RegisterProductDto product)
    {
        var ValidationErrors = Validator.Validate(product);
        if (ValidationErrors != null && ValidationErrors.Any())
        {
            throw new ValidationException(ValidationErrors);
        }

        return await ProductRepository.RegisterAsync(product);
    }
}
