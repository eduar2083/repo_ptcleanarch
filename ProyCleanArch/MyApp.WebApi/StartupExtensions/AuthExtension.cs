namespace MyApp.WebApi.StartupExtensions;

public static class AuthExtension
{
    public static WebApplicationBuilder AddCustomizedAuth(this WebApplicationBuilder builder)
    {
        IConfigurationSection JwtConfigurationSection = builder.Configuration.GetSection("Jwt");
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            JwtConfigurationSection.Bind(options.TokenValidationParameters);

            string PublicSigningKey = JwtConfigurationSection["PublicSigningKey"];
            byte[] KeyBlob = Convert.FromBase64String(PublicSigningKey);
            var CSP = new RSACryptoServiceProvider();
            CSP.ImportCspBlob(KeyBlob);
            var SecurityKey = new RsaSecurityKey(CSP);

            options.TokenValidationParameters.IssuerSigningKey = SecurityKey;
            options.SaveToken = bool.Parse(JwtConfigurationSection["SaveToken"]);
        });

        builder.Services.AddAuthorization(options =>
        {

        });

        return builder;
    }

    public static WebApplication UseCustomizedAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}