using PetClinic.API.Middlewares.ExceptionHandlerMiddleware;
using PetClinic.API.Middlewares.PreauthorizationMiddleware;

namespace PetClinic.API.Extensions;

public static class MiddlewareExtension
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    public static void ConfigurePreauthorizationMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuthMiddleware>();
    }
}
