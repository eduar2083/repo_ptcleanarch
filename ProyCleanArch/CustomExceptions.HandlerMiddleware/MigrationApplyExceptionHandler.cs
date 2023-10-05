namespace CustomExceptions.HandlerMiddleware;

internal sealed class MigrationApplyExceptionHandler
{
    public static ProblemDetails Handle(MigrationApplyException ex) =>
        new ProblemDetails()
        .FromHttp500InternalServerError("Error al aplicar la migración", nameof(MigrationApplyException));
}
