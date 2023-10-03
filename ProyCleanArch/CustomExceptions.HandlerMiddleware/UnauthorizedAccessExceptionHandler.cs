namespace CustomExceptions.HandlerMiddleware;

internal sealed class UnauthorizedAccessExceptionHandler
{
    public static ProblemDetails Handle(UnauthorizedAccessException ex) =>
        new ProblemDetails()
        .FromHttp401Unauthorized("Se requiere autenticación.", nameof(UnauthorizedAccessException));
}
