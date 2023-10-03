namespace CustomExceptions;

public class ValidationException : Exception
{
    public ValidationException() : base() { }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, Exception innerException) : base(message, innerException) { }

    public ValidationException(IEnumerable<DomainError> errors) :
        base(string.Join("\n", errors))
    {
        Errors = errors;
    }

    public IEnumerable<DomainError> Errors { get; }
}
