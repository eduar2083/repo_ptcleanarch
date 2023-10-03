namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app, params Assembly[] assemblies)
    {
        ExceptionHandlerHub.AddExceptionHandlers(assemblies);

        app.UseExceptionHandler(builder =>
        {
            builder.Run(async (context) =>
            {
                await ExceptionHandlerHub.WriteResponseAsync(context);
            });
        });

        return app;
    }
}