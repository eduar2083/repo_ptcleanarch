namespace MyApp.Controllers;

public static class DependencyContainer
{
    public static WebApplication UseMyAppControllers(this WebApplication app)
    {
        return app.AddControllersRouteEndpoint();
    }
}
