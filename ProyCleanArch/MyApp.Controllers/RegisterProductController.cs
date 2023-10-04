﻿namespace MyApp.Controllers;


internal sealed class RegisterProductController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(CrossMetadata.Group)
        .MapPost(CrossMetadata.Product_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra un producto", description: "Registrar un producto en el medio de persistencia."))
        .WithTags("Cross");
    }

    private static async Task<IResult> Register(RegisterProductDto newUser, IRegisterProductInputPort inputPort)
    {
        var Id = await inputPort.Register(newUser);

        return Results.Ok(Id);
    }
}