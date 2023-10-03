namespace CustomExceptions.HandlerMiddleware;

internal sealed class PersistenceExceptionHandler
{
    public static ProblemDetails Handle(PersistenceException ex) =>
        new ProblemDetails()
        .FromHttp500InternalServerError("Error al guardar los datos.", nameof(PersistenceException));
}
