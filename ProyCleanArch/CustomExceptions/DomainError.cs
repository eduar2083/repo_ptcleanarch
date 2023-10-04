namespace CustomExceptions;

public class DomainError
{
    public string Code { get; }
    public string Description { get; }

    public DomainError(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Code}: {Description}";
    }
}
