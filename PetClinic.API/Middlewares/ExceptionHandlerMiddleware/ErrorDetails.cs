namespace PetClinic.API.Middlewares.ExceptionHandlerMiddleware;

public class ErrorDetails
{
    public int StatusCode { get; set; } = default!;
    public string Message { get; set; } = default!;
}
