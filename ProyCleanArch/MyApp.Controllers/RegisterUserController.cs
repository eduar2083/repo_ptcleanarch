internal sealed class RegisterUserController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MyAppMetadata.Group)
        .MapPost(MyAppMetadata.User_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra un usuario", description: "Registrar un usuario en el medio de persistencia."))
        .WithTags("User");
    }

    private static async Task<IResult> Register(RegisterUserDto newUser, IRegisterUserInputPort inputPort)
    {
        var Id = await inputPort.Register(newUser);

        return Results.Ok(Id);
    }
}
