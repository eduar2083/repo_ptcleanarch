namespace MyApp.WebApi.StartupExtensions;

public static class SwaggerExtension
{
    public static WebApplicationBuilder AddCustomizedSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Prueba Técnica WebApi",
                Description = "Expone los principales Endpoints para esta prueba técnica",
                Contact = new OpenApiContact { Name = "Edinson Aldaz", Email = "edinson.aldaz@gmail.com", Url = new Uri("https://github.com/eduar2083") },
            });

            setup.AddSecurityDefinition("BearerToken", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Proporcionar el token JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "BearerToken"
                        }
                    },

                    new string[] { }
                }
            });

            setup.EnableAnnotations();
        });

        return builder;
    }

    public static WebApplication UseCustomizedSwagger(this WebApplication app)
    {
        if (!app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("v1/swagger.json", "Prueba Técnica v1.0");
            });
        }

        return app;
    }
}
