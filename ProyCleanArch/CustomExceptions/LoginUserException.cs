namespace CustomExceptions;

public sealed class LoginUserException : Exception
{
    public LoginUserException()
    {
    }

    public LoginUserException(string message) : base(message)
    {
    }

    public LoginUserException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    public LoginUserException(IEnumerable<DomainError> errors) :
        base(string.Join("\n", errors))
    {
        Errors = errors;
    }

    public IEnumerable<DomainError> Errors { get; }
}
