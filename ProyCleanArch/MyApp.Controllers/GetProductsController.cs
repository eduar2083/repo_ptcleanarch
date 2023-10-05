namespace MyApp.Controllers;

internal sealed class GetProductsController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapGet(CrossMetadata.Product_List, List)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .RequireAuthorization()
        .WithMetadata(new SwaggerOperationAttribute(summary: "Lista todos los productos", description: "Listar toos los productos."))
        .WithTags("Cross");
    }

    private static async Task<IResult> List([FromQuery] string slugTenant, IListProductsInputPort inputPort)
    {
        var Products = await inputPort.ListProductsAsync();

        return Results.Ok(Products);
    }
}
