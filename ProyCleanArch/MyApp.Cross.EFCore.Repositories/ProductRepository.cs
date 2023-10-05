namespace MyApp.Cross.EFCore.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly CrossContext Context;

    public ProductRepository(ITenantService tenantService)
    {
        var ConnectionString = tenantService.GetConnectionString();
        var Options = new DbContextOptionsBuilder<CrossContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        Context = new CrossContext(Options);
    }

    public async Task<int> RegisterAsync(RegisterProductDto product)
    {
        var NewProduct = product.ToProduct();

        try
        {
            Context.Add(NewProduct);
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return NewProduct.Id;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        try
        {
            return await Context.Products
                .Where(p => p.Id == id)
                .Select(p => p.ToProductDto())
                .FirstOrDefaultAsync();
        }
        catch
        {
            throw new RetrieveDataException();
        }
    }

    public async Task<List<ProductDto>> ListAsnc()
    {
        return await Context.Products
            .Select(p => p.ToProductDto())
            .ToListAsync();
    }
}
