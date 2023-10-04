namespace MyApp.Services;

internal sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8; // 128 bits
    private const int KeySize = 256 / 8; // 32 bits
    private const int Iterations = 10000;

    private static readonly HashAlgorithmName HashAlgorithName = HashAlgorithmName.SHA256;
    private static char Delimiter = ';';

    public string Hash(string inputPassword)
    {
        var SaltBytes = RandomNumberGenerator.GetBytes(SaltSize);
        var HashBytes = Rfc2898DeriveBytes.Pbkdf2(inputPassword, SaltBytes, Iterations, HashAlgorithName, KeySize);

        var Salt = Convert.ToBase64String(SaltBytes);
        var Hash = Convert.ToBase64String(HashBytes);

        var Result = string.Join(Delimiter, Salt, Hash);

        return Result;
    }

    public bool Check(string passwordHash, string inputPassword)
    {
        var Parts = passwordHash.Split(Delimiter, 3);

        if (Parts.Length != 2)
        {
            throw new FormatException("Unexpected hash format. " +
                "Should be formatted as `{salt}.{key}`");
        }

        var SaltBytes = Convert.FromBase64String(Parts[0]);
        var HashBytes = Convert.FromBase64String(Parts[1]);

        var HashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, SaltBytes, Iterations, HashAlgorithName, KeySize);

        return CryptographicOperations.FixedTimeEquals(HashBytes, HashInput);
    }
}