using System.Net;
using GameStore.Data.Exceptions;
using System.Text.Json;
public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

private static Task HandleExceptionAsync(HttpContext context, Exception ex)
{
    context.Response.ContentType = "application/json";
    int statusCode;
    string errorMessage;

    switch (ex)
    {
        case GameNotFoundException notFoundException:
            statusCode = (int)HttpStatusCode.NotFound;
            errorMessage = notFoundException.Message;
            break;
        case GameAliasExistsException conflictException:
            statusCode = (int)HttpStatusCode.Conflict;
            errorMessage = conflictException.Message;
            break;
        case GenreAliasExistsException conflictException:
            statusCode = (int)HttpStatusCode.Conflict;
            errorMessage = conflictException.Message;
            break;
        default:
            statusCode = (int)HttpStatusCode.InternalServerError;
            errorMessage = "An error occurred while processing the request.";
            break;
    }

    context.Response.StatusCode = statusCode;
    var errorResponse = JsonSerializer.Serialize(new { error = errorMessage });

    return context.Response.WriteAsync(errorResponse);
}
}