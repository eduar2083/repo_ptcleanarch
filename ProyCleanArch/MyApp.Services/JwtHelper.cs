namespace MyApp.Services;

internal static class JwtHelper
{
    public static List<Claim> GetUserClaims(UserDto user)
    {
        var DefaultUserClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Email),  // Este claim lo utilizan los esquemas de autenticación para identificar al usuario
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("FullName", user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };

        return DefaultUserClaims;
    }

    public static List<Claim> GetUserClaimsFromToken(string accessToken)
    {
        var Handler = new JwtSecurityTokenHandler();
        var Token = Handler.ReadJwtToken(accessToken);

        return Token.Claims.ToList();
    }

    public static string GetAccessToken(JwtOptions options, List<Claim> userClaims)
    {
        userClaims = userClaims.Where(t => t.Type != "aud").ToList();

        SigningCredentials SigningCredentials = GetSigningCredentials(options);
        JwtSecurityToken JwtSecurityToken = GetTokenOptions(options, SigningCredentials, userClaims);

        return new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
    }

    #region Helpers
    private static SigningCredentials GetSigningCredentials(JwtOptions options)
    {
        var KeyBlob = Convert.FromBase64String(options.PrivateSigningKey);
        var CSP = new RSACryptoServiceProvider();
        CSP.ImportCspBlob(KeyBlob);
        var SecurityKey = new RsaSecurityKey(CSP);

        return new SigningCredentials(key: SecurityKey,
                                      algorithm: SecurityAlgorithms.RsaSha512Signature)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };
    }

    private static JwtSecurityToken GetTokenOptions(JwtOptions options,
        SigningCredentials signingCredentials, List<Claim> userClaims)
    {
        var UtcNow = DateTime.UtcNow;

        JwtSecurityToken SecurityToken = new(
            issuer: options.ValidIssuer,
            audience: options.ValidAudience,
            claims: userClaims,
            notBefore: UtcNow,
            expires: UtcNow.Add(options.AccessTokenExpireIn),
            signingCredentials: signingCredentials);

        return SecurityToken;
    }
    #endregion
}
