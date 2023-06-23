using System.Net;
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
            
            var statusCode = _exceptionsService.GetStatusCodeAndMessageOnException(ex);
            var message = ex.Message;

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

    private ErrorDetails SetStatusCodeAndMessage(HttpStatusCode statusCode, string message)
    {
        return new ErrorDetails
        {
            StatusCode = (int)statusCode,
            Message = message,
        };
    }
}
