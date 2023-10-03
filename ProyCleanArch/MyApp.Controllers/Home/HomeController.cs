namespace MyApp.Controllers.Home;

internal sealed class HomeController
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/", async (context) =>
        {
            context.Response.ContentType = "text/plain; charset=utf8";
            await context.Response.WriteAsync($"El servicio MyApp se está ejecutando [Environment={app.Environment.EnvironmentName}] ...");
        });
    }
}
