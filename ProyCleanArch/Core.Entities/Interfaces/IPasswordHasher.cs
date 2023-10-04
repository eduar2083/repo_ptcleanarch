namespace Core.Entities.Interfaces;

public interface IPasswordHasher
{
    string Hash(string inputPassword);

    bool Check(string passwordHash, string inputPassword);
}