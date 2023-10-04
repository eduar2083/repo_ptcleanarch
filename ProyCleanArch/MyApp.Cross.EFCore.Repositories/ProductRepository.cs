namespace MyApp.Cross.EFCore.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly CrossContext Context;

    public ProductRepository(CrossContext context)
    {
        Context = context;
    }

    public async Task<int> RegisterAsync(RegisterProductDto product)
    {
        var NewProduct = product.ToProduct();
        Context.Add(NewProduct);

        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return NewProduct.Id;
    }
}
