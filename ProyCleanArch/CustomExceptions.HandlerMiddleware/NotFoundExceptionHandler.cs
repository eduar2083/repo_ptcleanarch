namespace CustomExceptions.HandlerMiddleware;

internal sealed class NotFoundExceptionHandler
{
    public static ProblemDetails Handle(NotFoundException ex) =>
        new ProblemDetails()
        .FromHttp400BadRequest("Recurso no encontrado.", nameof(NotFoundException));
}
