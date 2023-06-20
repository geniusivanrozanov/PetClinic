using System.Text.Json;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Middlewares.ExceptionHandlerMiddleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IExceptionsService _exceptionsService;

    public ExceptionHandlerMiddleware(RequestDelegate next, IExceptionsService exceptionsService)
    {
        _next = next;
        _exceptionsService = exceptionsService;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            ErrorDetails? errorDetails = null;

            // var statusCodeAndMessage = // _exceptionsService.GetStatusCodeAndMessageOnException(ex);
            var statusCode = 500; // statusCodeAndMessage.statusCode;
            var message = ex.Message; // statusCodeAndMessage.message;

            errorDetails = SetStatusCodeAndMessage(statusCode, message);

            await HandleExceptionAsync(httpContext, errorDetails);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, ErrorDetails errorDetails)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorDetails.StatusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
    }

    private ErrorDetails SetStatusCodeAndMessage(int statusCode, string message)
    {
        return new ErrorDetails
        {
            StatusCode = statusCode,
            Message = message,
        };
    }
}
