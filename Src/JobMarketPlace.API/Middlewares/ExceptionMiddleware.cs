using JobMarketPlace.Application.Common.Exceptions;
using System.Text.Json;

namespace JobMarketPlace.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExceptionMiddleware>
        _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                ex.Message);

            await HandleException(
                context,
                ex);
        }
    }

    private static async Task HandleException(
        HttpContext context,
        Exception ex)
    {
        context.Response.ContentType =
            "application/json";

        var statusCode =
            StatusCodes.Status500InternalServerError;

        object response;

        switch (ex)
        {
            case ApiException apiEx:

                statusCode =
                    apiEx.StatusCode;

                response = new
                {
                    success = false,

                    statusCode,

                    message = apiEx.Message,

                    traceId =
                        context.TraceIdentifier
                };

                break;

            default:

                response = new
                {
                    success = false,

                    statusCode,

                    message =
                        "An unexpected error occurred.",

                    traceId =
                        context.TraceIdentifier
                };

                break;
        }

        context.Response.StatusCode =
            statusCode;

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}
