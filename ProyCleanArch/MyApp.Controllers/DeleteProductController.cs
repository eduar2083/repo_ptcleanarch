namespace MyApp.Controllers;

internal sealed class DeleteProductController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapDelete(CrossMetadata.Product_Delete, Delete)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .RequireAuthorization()
        .WithMetadata(new SwaggerOperationAttribute(summary: "Elimina un producto", description: "Elimina un producto del medio de persistencia."))
        .WithTags("Cross");
    }

    private static async Task<IResult> Delete(int id, [FromQuery] string slugTenant, IDeleteProductInputPort inputPort)
    {
        bool Success = await inputPort.DeleteProductAsync(id);

        return Results.Ok(Success);
    }
}
