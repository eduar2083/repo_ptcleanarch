namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IPasswordHasher
{
    string Hash(string inputPassword);

    bool Check(string passwordHash, string inputPassword);
}