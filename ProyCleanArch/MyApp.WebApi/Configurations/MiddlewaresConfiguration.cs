﻿namespace MyApp.WebApi.Configurations;

public static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(this WebApplication app)
    {
        // Static files support
        app.UseStaticFiles();

        // Si nos invocan por Http, redireccionar a Https
        app.UseHttpsRedirection();

        // Error Handling
        app.UseCustomExceptionHandler(typeof(ExceptionHandlerHub).Assembly);

        // Swagger UI
        app.UseCustomizedSwagger();

        // Cors

        // Auth
        app.UseCustomizedAuth();

        // Endpoints
        app.UseMyAppControllers();

        // Response Headers Middleware

        return app;
    }
}
