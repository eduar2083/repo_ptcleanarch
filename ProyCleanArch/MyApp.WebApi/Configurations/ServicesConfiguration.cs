namespace MyApp.WebApi.Configurations;

public static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder builder)
    {
        // Swagger UI
        builder.AddCustomizedSwagger();

        // App Services
        builder.AddServices();

        // Auth
        builder.AddCustomizedAuth();

        // Cors

        return builder.Build();
    }
}
