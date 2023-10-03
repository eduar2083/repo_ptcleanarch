namespace CustomExceptions;

public class SendMessageException : Exception
{
    public SendMessageException() { }

    public SendMessageException(string message)
        : base(message) { }

    public SendMessageException(string message, Exception innerException)
        : base(message, innerException) { }
}