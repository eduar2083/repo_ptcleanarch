namespace MyApp.Controllers;

internal sealed class UpdateProductController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapPut(CrossMetadata.Product_Update, Update)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .RequireAuthorization()
        .WithMetadata(new SwaggerOperationAttribute(summary: "Actualiza un producto", description: "Actualiza un producto en el medio de persistencia."))
        .WithTags("Cross");
    }

    private static async Task<IResult> Update(UpdateProductDto product, [FromQuery] string slugTenant, IUpdateProductInputPort inputPort)
    {
        await inputPort.UpdateAsync(product);

        return Results.Ok();
    }
}
