namespace CustomExceptions;

public sealed class MigrationApplyException : Exception
{
    public MigrationApplyException()
    {
    }

    public MigrationApplyException(string message) : base(message)
    {
    }

    public MigrationApplyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
