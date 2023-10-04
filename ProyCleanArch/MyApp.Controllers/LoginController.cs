namespace MyApp.Controllers;

internal sealed class LoginController
{
    public static void Map(WebApplication app)
    {
        app.MapGroup(MasterMetadata.Group)
        .MapPost(MasterMetadata.Account_Login, Login)
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithMetadata(new SwaggerOperationAttribute(summary: "Autentica un usuario", description: "Autentica un usuario y devuelve el token de acceso."))
        .WithTags("Master");
    }

    private static async Task<IResult> Login(HttpContext context,
        UserCredentialsDto credentials,
        ILoginInputPort inputPort,
        ILoginOutputPort outputPort)
    {
        context.Response.Headers.Add("Cache-Control", "no-store");
        await inputPort.Login(credentials);

        return Results.Ok(outputPort.Tokens);
    }
}
