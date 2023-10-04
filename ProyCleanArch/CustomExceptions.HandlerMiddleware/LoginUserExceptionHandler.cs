namespace CustomExceptions.HandlerMiddleware;

internal sealed class LoginUserExceptionHandler
{
    public static ProblemDetails Handle(LoginUserException ex) =>
        new ProblemDetails()
        .FromHttp400BadRequest("Credenciales incorrectas", nameof(LoginUserException));
}