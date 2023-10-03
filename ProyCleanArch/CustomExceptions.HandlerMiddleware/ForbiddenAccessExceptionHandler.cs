namespace CustomExceptions.HandlerMiddleware;

internal sealed class ForbiddenAccessExceptionHandler
{
    public static ProblemDetails Handle(ForbiddenAccessException ex) =>
        new ProblemDetails()
        .FromHttp403Forbidden("Usted no está autorizado para acceder a este recurso.", nameof(ForbiddenAccessException));
}
