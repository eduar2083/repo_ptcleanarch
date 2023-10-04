namespace CustomExceptions.HandlerMiddleware;

public static class ExceptionHandlerHub
{
    private static Dictionary<Type, Delegate> ExceptionHandlers = new();

    public static void AddExceptionHandlers(Assembly[] assemblies)
    {
        foreach (Assembly Assembly in assemblies)
        {
            var HandlerTypes = Assembly.GetTypes()
            .Where(t => t.Name.EndsWith("ExceptionHandler") &&
            t.GetMethods().Any(m => m.Name == "Handle" &&
            m.GetParameters().Length == 1));

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

    private static async Task WritePoblemDetailsAsync(HttpContext context, ProblemDetails details)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status.Value;

        var Stream = context.Response.Body;
        await JsonSerializer.SerializeAsync(Stream, details);
    }
}