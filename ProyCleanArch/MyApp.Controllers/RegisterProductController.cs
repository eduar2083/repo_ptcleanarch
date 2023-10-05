﻿namespace MyApp.Controllers;


internal sealed class RegisterProductController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapPost(CrossMetadata.Product_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .RequireAuthorization()
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra un producto", description: "Registrar un producto en el medio de persistencia."))
        .WithTags("Cross");
    }

    private static async Task<IResult> Register(RegisterProductDto newUser, [FromQuery] string slugTenant, IRegisterProductInputPort inputPort)
    {
        var Id = await inputPort.RegisterAsync(newUser);

        return Results.Ok(Id);
    }
}
