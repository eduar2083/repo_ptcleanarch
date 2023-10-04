namespace Membership.ExceptionHandlerMiddleware;

public static class MembershipExceptionHandlerHub
{
    private static Dictionary<Type, Delegate> ExceptionHandlers = new();

    public static void AddExceptionHandlers(Assembly assembly)
    {
        var HandlerTypes = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("ExceptionHandler") &&
            t.GetMethods().Any(m => m.Name == "Handle" &&
            m.GetParameters().Length == 2));

        foreach (var Item in HandlerTypes)
        {
            var Method = Item.GetMethod("Handle");
            var ExceptionType = Method.GetParameters()[0].ParameterType;
            var ExceptionParameter = Expression.Parameter(ExceptionType, "ex");
            var BodyParameter = Expression.Call(null, Method, ExceptionParameter);
            var Lambda = Expression.Lambda(BodyParameter, ExceptionParameter);
            var Delegate = Lambda.Compile();

            ExceptionHandlers.TryAdd(ExceptionType, Delegate);
        }
    }

    public static async Task<bool> WriteResponseAsync(HttpContext context)
    {
        IExceptionHandlerFeature ExceptionDetail = context.Features.Get<IExceptionHandlerFeature>();
        Exception ExceptionError = ExceptionDetail?.Error;

        bool Handled = true;
        if (ExceptionError != null)
        {
            if (ExceptionHandlers.TryGetValue(ExceptionError.GetType(), out Delegate Handler))
            {
                await WritePoblemDetailsAsync(context, Handler.DynamicInvoke(ExceptionError) as ProblemDetails);
            }
        }

        return Handled;
    }

    public static ProblemDetails FromHttp400BadRequest(this ProblemDetails problem, string title, string instance, IEnumerable<MembershipError> errors = null)
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

    public static ProblemDetails FromHttp404NotFound(this ProblemDetails problem, string title, string instance, IEnumerable<MembershipError> errors = null)
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

    public static ProblemDetails FromHttp500InternalServerError(this ProblemDetails problem, string title, string instance, IEnumerable<MembershipError> errors = null)
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

    private static async Task WritePoblemDetailsAsync(HttpContext context, ProblemDetails details)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status.Value;

        var Stream = context.Response.Body;
        await JsonSerializer.SerializeAsync(Stream, details);
    }
}
