namespace Membership.Core.Services;

internal static class JwtHelper
{
    public static List<Claim> GetUserClaims(UserEntity user)
    {
        var DefaultUserClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Email),  // Este claim lo utilizan los esquemas de autenticación para identificar al usuario
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("FullName", user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };

        if (user.Claims != null)
        {
            DefaultUserClaims.AddRange(user.Claims);
        }

        foreach (var Role in user.Roles)
        {
            DefaultUserClaims.Add(new Claim(ClaimTypes.Role, Role));
        }

        return DefaultUserClaims;
    }

    public static List<Claim> GetUserClaimsFromToken(string accessToken)
    {
        var Handler = new JwtSecurityTokenHandler();
        var Token = Handler.ReadJwtToken(accessToken);

        return Token.Claims.ToList();
    }

    public static string GetAccessToken(JwtOptions options, string clientId, List<Claim> userClaims)
    {
        userClaims = userClaims.Where(t => t.Type != "aud").ToList();

        SigningCredentials SigningCredentials = GetSigningCredentials(options);
        JwtSecurityToken JwtSecurityToken = GetTokenOptions(options, SigningCredentials, clientId, userClaims);

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
        SigningCredentials signingCredentials, string clientId, List<Claim> userClaims)
    {
        var UtcNow = DateTime.UtcNow;

        JwtSecurityToken SecurityToken = new(
            issuer: options.ValidIssuer,
            audience: clientId,
            claims: userClaims,
            notBefore: UtcNow,
            expires: UtcNow.Add(options.AccessTokenExpireIn),
            signingCredentials: signingCredentials);

        return SecurityToken;
    }
    #endregion
}
