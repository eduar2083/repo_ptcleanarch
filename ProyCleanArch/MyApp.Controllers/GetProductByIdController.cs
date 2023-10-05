namespace MyApp.Controllers;

internal sealed class GetProductByIdController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapGet(CrossMetadata.Product_Get, GetById)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .RequireAuthorization()
        .WithMetadata(new SwaggerOperationAttribute(summary: "Obtiene un producto", description: "Recuperar un producto por su identificador."))
        .WithTags("Cross");
    }

    private static async Task<IResult> GetById(int id, [FromQuery] string slugTenant, IGetProductByIdInputPort inputPort)
    {
        var Product = await inputPort.GetByIdAsync(id);

        return Results.Ok(Product);
    }
}
