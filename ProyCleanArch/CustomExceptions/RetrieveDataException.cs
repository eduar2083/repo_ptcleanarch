namespace CustomExceptions;

public class RetrieveDataException : Exception
{
    public RetrieveDataException()
    { }

    public RetrieveDataException(string message)
        : base(message) { }

    public RetrieveDataException(string message, Exception innerException)
        : base(message, innerException) { }
}
