﻿internal sealed class RegisterUserController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MasterMetadata.Group)
        .MapPost(MasterMetadata.User_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra un usuario", description: "Registrar un usuario en el medio de persistencia."))
        .WithTags("Master");
    }

    private static async Task<IResult> Register(RegisterUserDto newUser, IRegisterUserInputPort inputPort)
    {
        var Id = await inputPort.RegisterAsync(newUser);

        return Results.Ok(Id);
    }
}
