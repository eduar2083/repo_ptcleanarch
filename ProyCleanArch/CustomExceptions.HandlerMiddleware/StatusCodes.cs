namespace CustomExceptions.HandlerMiddleware;

public class StatusCodes
{
    public const int Status200OK = 200;
    public const string Status200OKType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.1";

    public const int Status400BadRequest = 400;
    public const string Status400BadRequestType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";

    public const int Status401Unauthorized = 401;
    public const string Status401UnauthorizedErrorType = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";

    public const int Status403Forbidden = 403;
    public const string Status403ForbiddenErrorType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";

    public const int Status404NotFound = 404;
    public const string Status404NotFoundErrorType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";

    public const int Status500InternalServerError = 500;
    public const string Status500InternalServerErrorType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
}