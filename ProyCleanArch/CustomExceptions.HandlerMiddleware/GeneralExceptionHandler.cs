namespace CustomExceptions.HandlerMiddleware;

internal sealed class GeneralExceptionHandler
{
    public static ProblemDetails Handle(GeneralException ex) =>
        new ProblemDetails()
        .FromHttp500InternalServerError("Ha ocurrido un error interno en el servidor", nameof(GeneralException));
}