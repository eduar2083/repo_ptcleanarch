namespace MyApp.Cross.EFCore.Repositories.Mappers;

internal static class ProductMapper
{
    public static Product ToProduct(this RegisterProductDto newProduct) =>
        new Product
        {
            Name = newProduct.Name,
            UnitPrice = newProduct.UnitPrice
        };
}
