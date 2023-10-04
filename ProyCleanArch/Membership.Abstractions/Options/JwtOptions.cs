namespace Membership.Abstractions.Options;

public class JwtOptions
{
    public const string SectionKey = "Jwt";

    public string PrivateSigningKey { get; set; }
    public string PublicSigningKey { get; set; }
    public string ValidIssuer { get; set; }
    public TimeSpan AccessTokenExpireIn { get; set; }
    public TimeSpan RefreshTokenExpireIn { get; set; }
    public TimeSpan ClockSkew { get; set; }

    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }

    public bool SaveToken { get; set; }
}
