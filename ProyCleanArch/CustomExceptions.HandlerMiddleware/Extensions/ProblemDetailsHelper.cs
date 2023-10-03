namespace CustomExceptions.HandlerMiddleware.Extensions;

public static class ProblemDetailsHelper
{
    public static ProblemDetails FromHttp400BadRequest(this ProblemDetails problem, string title, string instance, IEnumerable<DomainError> errors = null)
    {
        problem.Status = StatusCodes.Status400BadRequest;
        problem.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        problem.Title = title;
        problem.Instance = $"problemDetails/{instance}";
        if (errors != null)
        {
            problem.Extensions.Add("errors", errors);
        }

        return problem;
    }

    public static ProblemDetails FromHttp401Unauthorized(this ProblemDetails problem, string title, string instance, IEnumerable<DomainError> errors = null)
    {
        problem.Title = title;
        problem.Status = StatusCodes.Status401Unauthorized;
        problem.Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
        problem.Instance = $"problemDetails/{instance}";
        if (errors != null)
        {
            problem.Extensions.Add("errors", errors);
        }

        return problem;
    }

    public static ProblemDetails FromHttp403Forbidden(this ProblemDetails problem, string title, string instance, IEnumerable<DomainError> errors = null)
    {
        problem.Title = title;
        problem.Status = StatusCodes.Status403Forbidden;
        problem.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";
        problem.Instance = $"problemDetails/{instance}";
        if (errors != null)
        {
            problem.Extensions.Add("errors", errors);
        }

        return problem;
    }

    public static ProblemDetails FromHttp404NotFound(this ProblemDetails problem, string title, string instance, IEnumerable<DomainError> errors = null)
    {
        problem.Title = title;
        problem.Status = StatusCodes.Status404NotFound;
        problem.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        problem.Instance = $"problemDetails/{instance}";
        if (errors != null)
        {
            problem.Extensions.Add("errors", errors);
        }

        return problem;
    }

    public static ProblemDetails FromHttp500InternalServerError(this ProblemDetails problem, string title, string instance, IEnumerable<DomainError> errors = null)
    {
        problem.Title = title;
        problem.Status = StatusCodes.Status500InternalServerError;
        problem.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        problem.Instance = $"problemDetails/{instance}";
        if (errors != null)
        {
            problem.Extensions.Add("errors", errors);
        }
        return problem;
    }
}
