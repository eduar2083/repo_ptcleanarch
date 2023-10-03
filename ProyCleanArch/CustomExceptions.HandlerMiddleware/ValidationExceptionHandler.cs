namespace CustomExceptions.HandlerMiddleware;

internal sealed class ValidationExceptionHandler
{
    public static ProblemDetails Handle(ValidationException ex) =>
        new ProblemDetails()
        .FromHttp400BadRequest("Error de validación.", nameof(ValidationExceptionHandler), ex.Errors);
}
