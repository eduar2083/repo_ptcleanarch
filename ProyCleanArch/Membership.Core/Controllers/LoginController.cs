namespace Membership.Core.Controllers;

internal sealed class LoginController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MembershipEndpoints.Group)
        .MapPost(MembershipEndpoints.Account_Login, Login)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Autentica un usuario", description: "Autentica un usuario y devuelve un token de acceso."))
        .WithTags("Account");
    }

    private static async Task<IResult> Login(HttpContext context,
        UserCredentialsDto credentials,
        ILoginInputPort inputPort,
        ILoginOutputPort outputPort)
    {
        context.Response.Headers.Add("Cache-Control", "no-store");
        await inputPort.LogingAsync(credentials);

        return Results.Ok(outputPort.Tokens);
    }
}
