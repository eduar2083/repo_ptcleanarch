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
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => p.ToProductDto())
                .FirstOrDefaultAsync();
        }
        catch
        {
            throw new RetrieveDataException();
        }
    }

    public async Task<List<ProductDto>> ListAsync()
    {
        return await Context.Products
            .AsNoTracking()
            .Select(p => p.ToProductDto())
            .ToListAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var Product = await Context.Products.FindAsync(id);
        Context.Remove(Product);

        return await Context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(UpdateProductDto product)
    {
        var FoundProduct = await Context.Products.FindAsync(product.Id);
        FoundProduct.Name = product.Name;
        FoundProduct.UnitPrice = product.UnitPrice;

        await Context.SaveChangesAsync();
    }
}
