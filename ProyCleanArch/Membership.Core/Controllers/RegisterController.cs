namespace Membership.Core.Controllers;

internal sealed class RegisterUserController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MembershipEndpoints.Group)
        .MapPost(MembershipEndpoints.User_Register, Register)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Registra un usuario", description: "Registrar un usuario en el medio de persistencia."))
        .WithTags("User");
    }

    private static async Task<IResult> Register(RegisterUserDto newUser, IRegisterUserInputPort inputPort)
    {
        await inputPort.RegisterAsync(newUser);

        return Results.Ok();
    }
}
