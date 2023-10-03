namespace CustomExceptions.HandlerMiddleware;

internal sealed class RetrieveDataExceptionHandler
{
    public static ProblemDetails Handle(RetrieveDataException ex) =>
        new ProblemDetails()
        .FromHttp500InternalServerError("Error al recuperar los datos.", nameof(RetrieveDataExceptionHandler));
}
