using PetClinic.API.Middlewares.ExceptionHandlerMiddleware;

namespace PetClinic.API.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
