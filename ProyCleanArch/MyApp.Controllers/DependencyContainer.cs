namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static WebApplication UseMyAppControllers(this WebApplication app)
    {
        return app.AddControllersRouteEndpoint();
    }
}
