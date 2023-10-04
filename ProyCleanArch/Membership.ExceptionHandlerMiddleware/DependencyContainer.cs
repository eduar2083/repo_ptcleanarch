namespace Membership.ExceptionHandlerMiddleware;

public static class DependencyContainer
{
    public static IApplicationBuilder UseMembershipExceptionHandler(this IApplicationBuilder app)
    {
        MembershipExceptionHandlerHub.AddExceptionHandlers(Assembly.GetExecutingAssembly());

        app.UseExceptionHandler(builder =>
        {
            builder.Run(async (context) =>
            {
                await MembershipExceptionHandlerHub.WriteResponseAsync(context);
            });
        });

        return app;
    }
}
